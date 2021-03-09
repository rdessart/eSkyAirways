using Performances.PerformancesData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UnitsNet;

namespace Performances
{
    public class AircraftPerformance
    {
        public string Name { get; set; }
        public Dictionary<string, HoldData> Hold { get; set; }
        public Dictionary<string, CruiseData> Cruise { get; set; }
        public Dictionary<string, ClimbData> Climb { get; set; }
        public int ZeroFuelWeight { get; set; }
        public int FuelStart { get; set; }
        public int FuelOnBoard { get; set; }
        public int GrossWeight { get; set; }

        public AircraftPerformance()
        {
            Hold = new Dictionary<string, HoldData>();
            Cruise = new Dictionary<string, CruiseData>();
            Climb = new Dictionary<string, ClimbData>();
        }

        public bool Open(string filepath)
        {
            string localPath = Path.GetFullPath(Path.Combine(filepath, ".."));
            JsonDocument jDoc = JsonDocument.Parse(File.ReadAllText(filepath));
            JsonElement root = jDoc.RootElement;
            Name = root.GetProperty("Aircraft Type").GetString();
            JsonElement files = root.GetProperty("Performances");
            string holdPath = Path.Combine(localPath, files.GetProperty("Hold").GetString());
            string cruisePath = Path.Combine(localPath, files.GetProperty("Cruise").GetString());
            string climbPath = Path.Combine(localPath, files.GetProperty("Climb").GetString());
            System.Console.WriteLine($"{Name}\n\t-Hold : {holdPath}\n\t-Climb : {climbPath}\n\t-Cruise : {cruisePath}");

            if(File.Exists(holdPath))
            {
                Hold = JsonSerializer.Deserialize<Dictionary<string, HoldData>>(File.ReadAllText(holdPath));
            }
            if (File.Exists(cruisePath))
            {
                Cruise = JsonSerializer.Deserialize<Dictionary<string, CruiseData>>(File.ReadAllText(cruisePath));
            }
            if (File.Exists(climbPath))
            {
                Climb = JsonSerializer.Deserialize<Dictionary<string, ClimbData>>(File.ReadAllText(climbPath));
            }
            return true;
        }
        public static float Map(int X, int A, int B, int C, int D)
        {
            return (float)(X - A) / (float)(B - A) * (float)(D - C) + C;
        }
        private float? findIndexesInList(int value, List<int> list)
        {
            if (list.Contains(value))
            {
                return list.IndexOf(value);
            }
            else
            {
                for(int index=0; index < list.Count - 1; index ++)
                {
                    if(list[index] <= value  && list[index+1] >=  value)
                    {
                        return Map(value, list[index], list[index + 1], index, index + 1);
                    }
                }
            }
            return null;
        }
        public Mass? GetHoldingFuel(Length altitude, Mass grossWeight, TimeSpan time)
        {
            if(Hold is null)
            {
                throw new Exception("Hold data not available !");
            }
            HoldData data = Hold["Default"];
            float? alt_indexes = findIndexesInList((int)altitude.Feet, data.FuelFlow["Altitude"]);
            if(!alt_indexes.HasValue)
            {
                if((int)altitude.Feet < data.FuelFlow["Altitude"][0])
                {
                    alt_indexes = 0.0f;
                }
                else if ((int)altitude.Feet > data.FuelFlow["Altitude"][data.FuelFlow["Altitude"].Count])
                {
                    alt_indexes = (float)data.FuelFlow["Altitude"].Count;
                }
            }
            
            List<int> weights = new List<int>();
            var iterator = data.FuelFlow.Keys.GetEnumerator();
            iterator.MoveNext();
            while (iterator.MoveNext())
            {
                weights.Add(int.Parse(iterator.Current));
            }
            float? weight_index = findIndexesInList((int)Math.Round(grossWeight.Kilograms), weights);
            if (!weight_index.HasValue)
            {
                if ((int)grossWeight.Kilograms < weights[0])
                {
                    weight_index = 0.0f;
                }
                else
                {
                    throw new Exception("Aircraft too heavy !");
                }
            }
            int A = data.FuelFlow[weights[(int)Math.Floor(weight_index.Value)].ToString()][(int)Math.Floor(alt_indexes.Value)];
            int B = data.FuelFlow[weights[(int)Math.Ceiling(weight_index.Value)].ToString()][(int)Math.Floor(alt_indexes.Value)];
            int C = data.FuelFlow[weights[(int)Math.Floor(weight_index.Value)].ToString()][(int)Math.Ceiling(alt_indexes.Value)];
            int D = data.FuelFlow[weights[(int)Math.Ceiling(weight_index.Value)].ToString()][(int)Math.Ceiling(alt_indexes.Value)];
            float w_index = (float)Math.Floor(weight_index.Value);
            float dw_index = weight_index.Value - w_index;
            float AB = (A + B) * dw_index;
            float CD = (C + D) * dw_index;

            float a_index = (float)Math.Floor(alt_indexes.Value);
            float da_index = alt_indexes.Value - a_index;
            float fuel = (AB + CD) * dw_index;
            return Mass.FromKilograms(fuel * (time.TotalMinutes / 60.0));
        }
    }
}

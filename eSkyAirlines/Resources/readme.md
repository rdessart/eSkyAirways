# Data formating
## AircraftType
AircraftType description should be place in the `data/` directory
Naming convention is `[AircraftType].json` (example A320-214.json).
### Mandatory Content
AircraftType : [string] the type of aircraft (can be more detailed than the filename)
Performances : [dictionary] with the relative path to the specific performance file.
               inclunding : Climb, Cruise, Descent, Hold, Alternate.
               if the aircraft don't have a performance file, set value to `null` the program will look for the best performance remplacement.
               For example if hold is null, we will take the lower possible cruise altiude in LRC
## Aircraft Performance File
Json file containing the performance for on aircraft and one phase of flight.

               

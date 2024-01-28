using System;

namespace eSkyAirways.ClientUI.Models;

public class PageModel(string caption, Type vmType)
{
    public string Caption { get; set; } = caption;
    public Type DataModelType { get; set; } = vmType;
}
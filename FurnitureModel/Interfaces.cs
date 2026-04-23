using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public interface IInventoryItem
    {
        int InventoryQuantity { get; set; }
        void DisplayDetails();

        //static
    }

    public interface IOutdoorDurable
    {
        int WeatherResistanceLevel { get; set; }
        (int Min, int Max) TemperatureSpan { get; set; }
    }

    public interface IAssemblyRequired
    {
        void GetAssemblyInstructions();
        List<string> AssemblyTools { get; }
    }
}

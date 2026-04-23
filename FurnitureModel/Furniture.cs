using System.Runtime.CompilerServices;

namespace FurnitureModel
{
    public enum FurnitureType
    {
        RockingChair = 1,
        GardenChair = 2,
        Sofa = 3,
        BedroomCloset = 4,
        BookShelf = 5
    }

    public abstract class Furniture : IInventoryItem
    {
        internal Furniture(int id)
        {
            this.ID = id;
        }

        private Furniture() { }

        public int ID { get; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? EANCode { get; set; }
        public int InventoryQuantity { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Izdelek {this.Name} [{this.InventoryQuantity}] - {this.Price:0.00}\n" +
                $"Opis: {this.Description}");
        }

        internal static List<string> ParameterList()
        {
            return new List<string>() { "Name", "Description", "Price", "EANCode", "InventoryQuantity" };
        }
    }

    public abstract class SeatingFurniture : Furniture
    {
        internal SeatingFurniture(int id) : base(id) { }

        public int Capacity { get; internal set; }

        public bool IsUpholstered { get; set; }

        new internal static List<string> ParameterList()
        {
            var lst = Furniture.ParameterList();
            lst.AddRange(["Capacity", "IsUpholstered"]);
            return lst;
        }
    }

    public abstract class StorageFurniture : Furniture
    {
        internal StorageFurniture(int id) : base(id) { }

        public int MaxWeightCapacity { get; internal set; }

        public Material Material { get; set; }
    }

    public enum Material
    {
        Wood,
        Glass,
        Plastic
    }


    public class RockingChair : SeatingFurniture
    {
        internal RockingChair(int id) : base(id) { }

        public double Radius { get; set; }
        public bool HasArmrests { get; set; }
    }

    public class GardenChair : SeatingFurniture, IOutdoorDurable, IAssemblyRequired
    {
        internal GardenChair(int id) : base(id)
        {
            this.AssemblyTools = new();
        }

        public int LegCount { get; set; }


        #region IOutdoorDurable

        public int WeatherResistanceLevel { get; set; }
        public (int Min, int Max) TemperatureSpan { get; set; }

        #endregion


        #region IAssemblyRequired

        public List<string> AssemblyTools { get; }

        public void GetAssemblyInstructions()
        {
            Console.WriteLine("Sestavi ga!");
        }

        #endregion
    }

    public class Sofa : SeatingFurniture
    {
        internal Sofa(int id) : base(id) { }

        public string? FabricType { get; set; }

        new internal static List<string> ParameterList()
        {
            var lst = SeatingFurniture.ParameterList();
            lst.AddRange(["FabricType"]);
            return lst;
        }
    }

    public class BedroomCloset : StorageFurniture
    {
        internal BedroomCloset(int id) : base(id) { }

        public int DoorCount { get; set; }
    }

    public class BookShelf : StorageFurniture, IAssemblyRequired
    {
        internal BookShelf(int id) : base(id) 
        {
            this.AssemblyTools = new();
        }

        public int ShelfCount { get; set; }
        public bool IsWallMounted { get; set; }


        #region IAssemblyRequired

        public List<string> AssemblyTools { get; }

        public void GetAssemblyInstructions()
        {
            Console.WriteLine("Sestavi jo!");
        }

        #endregion

    }
}

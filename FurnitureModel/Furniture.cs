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

    public enum ParameterName
    {
        Name = 1,
        Description = 2,
        Price = 3,
        EANCode = 4,
        InventoryQuantity = 5,
        Capacity = 6,
        IsUpholstered = 7,
        FabricType = 8
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

        internal static List<ParameterName> ParameterList()
        {
            return new List<ParameterName>()
                {
                ParameterName.Name,
                ParameterName.Description,
                ParameterName.Price,
                ParameterName.EANCode,
                ParameterName.InventoryQuantity
            };
        }
    }

    public abstract class SeatingFurniture : Furniture
    {
        internal SeatingFurniture(int id) : base(id) { }

        public int Capacity { get; internal set; }

        public bool IsUpholstered { get; set; }

        new internal static List<ParameterName> ParameterList()
        {
            var lst = Furniture.ParameterList();
            lst.AddRange([ParameterName.Capacity, ParameterName.IsUpholstered]);
            return lst;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Kapaciteta: {this.Capacity}\n" +
                $"Je oblazinjeno: {this.IsUpholstered}");
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

        new internal static List<ParameterName> ParameterList()
        {
            var lst = SeatingFurniture.ParameterList();
            lst.AddRange([ParameterName.FabricType]);
            return lst;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Tip blaga: {this.FabricType}");
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

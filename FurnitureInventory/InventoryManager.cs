using FurnitureModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureInventory
{
    public sealed class InventoryManager
    {
        private InventoryManager(string name, string address)
        {
            this.Items = new List<Furniture>();
            this.BasicData = new BasicData() { Name = name, Address = address };
        }

        public BasicData BasicData { get; }
        public List<Furniture> Items { get; }

        private static InventoryManager? instance = null;

        public static InventoryManager GetInstance(string name, string address)
        {
            if (instance == null)
            {
                instance = new InventoryManager(name, address);
            }
            return instance;
        }
    }

    public record BasicData
    {
        public string? Name { get; init; }
        public string? Address { get; init; }
    }
}

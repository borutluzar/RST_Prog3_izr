using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public interface IFurnitureBuilder
    {
        void SetName(string name);
        void SetDescription(string description);
        void SetPrice(decimal price);
        void SetEANCode(string ean);
        void SetInventoryQuantity(int quantity);
        Furniture Build();
    }

    public interface ISeatingFurnitureBuilder : IFurnitureBuilder
    {
        void SetCapacity(int capacity);
        void SetIsUpholstered(bool isUH);
    }

    public interface ISofaBuilder : ISeatingFurnitureBuilder
    {
        void SetFabricType(string fabricType);
    }


    internal class SofaBuilder : ISofaBuilder
    {
        private Sofa builderInstance;

        internal SofaBuilder(int id)
        {
            builderInstance = new Sofa(id);
        }

        public void SetDescription(string description)
        {
            builderInstance.Description = description;
        }

        public void SetEANCode(string ean)
        {
            builderInstance.EANCode = ean;
        }

        public void SetFabricType(string fabricType)
        {
            builderInstance.FabricType = fabricType;
        }

        public void SetInventoryQuantity(int quantity)
        {
            builderInstance.InventoryQuantity = quantity;
        }

        public void SetName(string name)
        {
            builderInstance.Name = name;
        }

        public void SetPrice(decimal price)
        {
            builderInstance.Price = price;
        }        

        public void SetCapacity(int capacity)
        {
            builderInstance.Capacity = capacity;
        }

        public void SetIsUpholstered(bool isUH)
        {
            builderInstance.IsUpholstered = isUH;
        }

        public Furniture Build()
        {
            return builderInstance;
        }
    }
}

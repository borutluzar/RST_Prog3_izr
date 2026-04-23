using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public class FurnitureFactory
    {
        public static Furniture? Create(FurnitureType type, Dictionary<ParameterName, string> dicParValues)
        {
            Furniture? furniture = null;
            int id = new Random().Next(0, 100_000);

            switch (type)
            {
                case FurnitureType.BedroomCloset:
                    break;

                case FurnitureType.BookShelf:
                    break;

                case FurnitureType.GardenChair:
                    break;

                case FurnitureType.RockingChair:
                    break;

                case FurnitureType.Sofa:
                    SofaBuilder builder = new SofaBuilder(id);
                    builder.SetName(dicParValues[ParameterName.Name]);
                    builder.SetDescription(dicParValues[ParameterName.Description]);
                    builder.SetPrice(decimal.Parse(dicParValues[ParameterName.Price]));
                    builder.SetEANCode(dicParValues[ParameterName.EANCode]);
                    builder.SetInventoryQuantity(int.Parse(dicParValues[ParameterName.InventoryQuantity]));
                    builder.SetCapacity(int.Parse(dicParValues[ParameterName.Capacity]));
                    builder.SetIsUpholstered(bool.Parse(dicParValues[ParameterName.IsUpholstered]));
                    builder.SetFabricType(dicParValues[ParameterName.Capacity]);
                    furniture = builder.Build();
                    break;
            }
            return furniture;
        }

        public static List<ParameterName>? GetParameterList(FurnitureType type)
        {
            List< ParameterName>? lstPars = null;
            switch (type)
            {
                case FurnitureType.BedroomCloset:
                    lstPars = BedroomCloset.ParameterList();
                    break;
                case FurnitureType.BookShelf:
                    lstPars = BookShelf.ParameterList();
                    break;
                case FurnitureType.GardenChair:
                    lstPars = GardenChair.ParameterList();
                    break;
                case FurnitureType.RockingChair:
                    lstPars = RockingChair.ParameterList();
                    break;
                case FurnitureType.Sofa:
                    lstPars = Sofa.ParameterList();
                    break;
            }
            return lstPars;
        }
    }
}

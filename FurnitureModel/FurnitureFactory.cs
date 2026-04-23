using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public class FurnitureFactory
    {
        public static Furniture? Create(FurnitureType type, Dictionary<string, string> dicParValues)
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
                    var lst = Sofa.ParameterList();

                    furniture = new Sofa(id);
                    break;
            }
            return furniture;
        }

        public static List<string>? GetParameterList(FurnitureType type)
        {
            List<string>? lstPars = null;
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

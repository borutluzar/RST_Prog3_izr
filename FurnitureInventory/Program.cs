using FurnitureModel;
using Newtonsoft.Json;

namespace FurnitureInventory
{
    public class Program
    {
        private static string INVENTORY_NAME = "FIS";
        private static string INVENTORY_ADDRESS = "Bršljin";

        public static void Main(string[] args)
        {
            Console.WriteLine("Dobrodošli v skladišču!");
            InventoryManager manager = InventoryManager.GetInstance(INVENTORY_NAME, INVENTORY_ADDRESS);

            while (true)
            {
                Console.WriteLine("\nIzberite eno od možnosti:\n" +
                    "1 - Dodaj nov predmet\n" +
                    "2 - Izpiši pohištvo\n" +
                    "3 - Shrani v datoteko\n" +
                    "4 - Naloži iz datoteke\n" +
                    "5 - Izhod iz programa\n");
                Console.Write("Vaša izbira: ");
                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Izberite tip predmeta:");
                            FurnitureType type = AuxiliaryFunctions.ChooseOption<FurnitureType>();

                            Console.WriteLine($"Izbrali ste tip {type}");
                            // Pridobimo parametre za kreiranje instance
                            var dicParVal = GetParameterValues(FurnitureFactory.GetParameterList(type) ?? new List<ParameterName>());

                            // Kreiramo instanco
                            Furniture? instance = FurnitureFactory.Create(type, dicParVal);
                            if (instance != null)
                                manager.Items.Add(instance);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("V skladišču imamo naslednje predmete: ");
                            foreach (var item in manager.Items)
                            {
                                item.DisplayDetails();
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Write($"Vpišite ime datoteke: ");
                            string fileName = Console.ReadLine();
                            Console.WriteLine($"Shranjujemo v datoteko {fileName}");
                            SaveInFile(fileName, manager.Items);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Hvala in nasvidenje!");
                        return;
                }
            }
        }

        private static Dictionary<ParameterName, string> GetParameterValues(List<ParameterName> lstParameters)
        {
            Dictionary<ParameterName, string> dicParams = new();

            foreach (var par in lstParameters)
            {
                Console.Write($"Vpišite vrednost za parameter {par}: ");
                string val = Console.ReadLine() ?? string.Empty;

                dicParams.Add(par, val);
            }
            return dicParams;
        }

        private static void SaveInFile(string fileName, List<Furniture> lstItems)
        {
            StreamWriter sw = new StreamWriter(fileName);

            string json = JsonConvert.SerializeObject(lstItems);
            sw.WriteLine(json);

            // Preveriti, kako je s tipi objektov - kako vemo, kdo je kdo!

            /*
            foreach (var item in lstItems) 
            {
                string json = JsonConvert.SerializeObject(item);
                sw.WriteLine(json);
            }
            */
            sw.Close();
        }
    }
}

using FurnitureModel;

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
                    "3 - Izhod iz programa\n");
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
                            var dicParVal = GetParameterValues(FurnitureFactory.GetParameterList(type) ?? new List<string>());
                            
                            // Kreiramo instanco
                            Furniture? instance = FurnitureFactory.Create(type, dicParVal);
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Hvala in nasvidenje!");
                        return;
                }
            }
        }

        private static Dictionary<string, string> GetParameterValues(List<string> lstParameters)
        {
            Dictionary<string, string> dicParams = new ();

            foreach(var par in lstParameters)
            {
                Console.Write($"Vpišite vrednost za parameter {par}: ");
                string val = Console.ReadLine();

                dicParams.Add(par, val);
            }
            return dicParams;
        }
    }
}

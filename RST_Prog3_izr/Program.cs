using System.Drawing;

namespace RST_Prog3_izr
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            TableOld mizaVKuhinji = new TableOld(12);
            TableOld mizaVDnevni = new TableOld(22);
            TableOld mizaNaHodniku = new TableOld(42);

            // Poskusimo zamenjati serijsko številko
            //mizaVKuhinji.serNum = 3;

            //mizaVKuhinji.SerialNumber = 3;
            mizaVKuhinji.Material = Material.Stone;
            mizaVKuhinji.numLegs = 4;
            mizaVKuhinji.Color = "modra";

            Console.WriteLine($"Miza {nameof(mizaVKuhinji)} ima serijsko številko {mizaVKuhinji.SerialNumber}.");
            Console.WriteLine($"Miza {nameof(mizaVDnevni)} ima serijsko številko {mizaVDnevni.SerialNumber}.");
            */

            // Dedovanje
            /*
            Furniture omara = new Furniture(1);
            Console.WriteLine($"Naša omara: {omara.ToString()}");
            omara.Pack();

            Table miza = new Table(2) { Dimensions = new Dimension() { Height = 80, Width = 60, Length = 80}, LoadCapacity = 400 };
            DiningTable jedilnaMiza = new DiningTable(3);
            ClubTable klubska = new ClubTable(4);
            
            Console.WriteLine($"Naša miza: {miza}");
            miza.Pack();
            // Lahko pa pokličem Pack iz nadrazreda
            ((Furniture)miza).Pack();

            var test = (Furniture)miza;            
            test.Pack();

            // Polimorfizmi
            List<Furniture> lstPohistvo = new List<Furniture>() 
            { 
                omara,
                miza,
                jedilnaMiza,
                klubska,
                test
            };
            foreach(var pohistvo in lstPohistvo)
            {
                pohistvo.Pack();
            }
            */

            /*
            ChessPiece figura = new Queen(Color.Black) { Position = new ChessBoardField(1, 1) };
            Console.WriteLine($"{figura}");
            figura.Move(new ChessBoardField(1, 2));
            Console.WriteLine($"{figura}");
            //object x = figura.Dummy;      
            //((Queen)figura).Dummy;
            */

            /*
            Application gta6 = new Application("EA Games", "Matjaž");
            Application gemini = new Application("Google", "Tony");
            File exam = new File("Borut");
            Exhibition exhib = new Exhibition("Vincent");

            List<IMetaData> lst = new List<IMetaData>() { gta6, gemini, exam, exhib };

            foreach (IMetaData item in lst) 
            {
                Console.WriteLine($"Vmesniki, katerim instanca pripada: {string.Join(", ", item.GetType().GetInterfaces())}");
                Console.WriteLine($"Avtor objekta je {item.Author}");

                // item je tipa IMetaData, zato ne vidi lastnosti RAMConsumption
                //item.RAMConsumption

                // Objekt gta6 jo vidi
                //gta6.RAMConsumption

                // Uporabimo is in casting
                if(item is Application)
                {                    
                    Console.WriteLine($"Poraba RAM-a je {((Application)item).RAMConsumption}");
                }
                if(item is IExample)
                {
                    Console.WriteLine($"IExample avtor pa je {((IExample)item).Author}");
                }
            }
            */

            // Primer singletona
            Singleton single = Singleton.GetInstance();

            EventLog evnt = EventLog.GetInstance();
            evnt.WriteEvent("Zgodil se je dogodek!");

            Event1();
            Event2();

            Console.WriteLine("Program se zaključuje!");

            Console.ReadLine();
        }

        public static void Event1()
        {
            EventLog evnt = EventLog.GetInstance();
            evnt.WriteEvent("Zgodil se je dogodek 2!");
        }

        public static void Event2()
        {
            EventLog evnt = EventLog.GetInstance();
            evnt.WriteEvent("Zgodil se je dogodek 3!");
        }
    }
}

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

            ChessPiece figura = new Queen(Color.Black) { Position = new ChessBoardField(1,1)};
            Console.WriteLine($"{figura}");            
            figura.Move(new ChessBoardField(1, 2));
            Console.WriteLine($"{figura}");


            Console.ReadLine();
        }
    }
}

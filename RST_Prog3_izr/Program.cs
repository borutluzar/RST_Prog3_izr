namespace RST_Prog3_izr
{
    public class Program
    {
        static void Main(string[] args)
        {
            Table mizaVKuhinji = new Table(12);
            Table mizaVDnevni = new Table(22);
            Table mizaNaHodniku = new Table(42);

            // Poskusimo zamenjati serijsko številko
            //mizaVKuhinji.serNum = 3;

            //mizaVKuhinji.SerialNumber = 3;
            mizaVKuhinji.Material = Material.Stone;
            mizaVKuhinji.numLegs = 4;
            mizaVKuhinji.Color = "modra";

            Console.WriteLine($"Miza {nameof(mizaVKuhinji)} ima serijsko številko {mizaVKuhinji.SerialNumber}.");
            Console.WriteLine($"Miza {nameof(mizaVDnevni)} ima serijsko številko {mizaVDnevni.SerialNumber}.");
            Console.ReadLine();
        }
    }
}

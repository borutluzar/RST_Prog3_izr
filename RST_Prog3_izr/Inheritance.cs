using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{

    /*      
     *      Primer hierarhije pohištva
     *      
    Furniture (serialNumber, price, material) -> Pack
        Table (surface, dimensions, loadCapacity, numOfLegs) -> Pack
            DiningTable (isExpandible)
            ClubTable (hasShelf, isFoldable)
        Chair 
            LawnChair
            RockingChair
            DiningChair    
        Closet
            BathroomBox
            BedroomCloset
    */


    public class Furniture
    {
        // Lastnost nima elementa set => je samo za branje (read-only)
        public int SerialNumber { get; } = 4;

        public double Price { get; set; }

        public Material Material { get; set; }


        public Furniture(int sn)
        {
            this.SerialNumber = sn;
        }

        public override string ToString()
        {
            return $"[{this.SerialNumber}]: cena = {this.Price:0.00}, material: {this.Material}";
        }

        public virtual void Pack()
        {
            Console.WriteLine("Pohištvo je bilo uspešno zapakirano!");
        }
    }

    public class Table : Furniture
    {
        public int NumLegs { get; set; }

        // Samodejno implementirana lastnost
        public string Color { get; set; }

        public Dimension Dimensions { get; set; }

        public double Surface { get; }

        public double LoadCapacity { get; set; }

        /// <summary>
        /// Konstruktor za kreiranje mize s serijsko številko
        /// </summary>
        /// <param name="sn">Vrednost serijske številke</param>
        public Table(int sn) : base(sn)
        {
            this.NumLegs = 4;
        }

        public override string ToString()
        {
            return base.ToString() + $", dimenzije: {this.Dimensions:0.00}, nosilnost: {this.LoadCapacity:0.00}";
        }

        // Funkcijo lahko povozimo, če je imela v nadrazredu določilo virtual ali override        
        public override void Pack()
        {
            Console.WriteLine("Miza je bila uspešno zapakirana!");
        }
        

        // Funkcija, ki ni prepisana,
        // ampak je popolnoma nova z enakim imenom kot funkcija iz nadrazreda
        /*
        public new void Pack()
        {
            Console.WriteLine("Tole je čisto neka druga funkcija Pack!");
        }
        */
    }

    public struct Dimension
    {
        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        public override string ToString()
        {
            return $"Višina: {Height:0.00}, dolžina: {Length:0.00}, širina: {Width:0.00}";
        }
    }

    // Z določilom sealed ustavimo nadaljnje dedovanje razreda
    public sealed class DiningTable : Table
    {
        public DiningTable(int sn) : base(sn) { }

        public bool IsExtendible { get; set; }
    }

    public class ClubTable : Table
    {
        public ClubTable(int sn) : base(sn) { }

        public bool IsFoldable { get; set; }
        
        public bool HasShelf { get; set; }

        public override void Pack()
        {
            Console.WriteLine("Klubska mizica je bila uspešno zapakirana!");
        }
    }
}

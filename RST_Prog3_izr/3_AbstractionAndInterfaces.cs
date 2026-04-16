using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace RST_Prog3_izr
{
    public class BoardField
    {
        // Iščemo primerno lastnost

        public override string ToString()
        {
            return $"Samo za primer!";
        }
    }

    public class ChessBoardField : BoardField
    {
        public ChessBoardField(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    public interface IMoveable
    {
        public bool Move(BoardField field);
        public bool SetStartPosition(BoardField field);
    }


    /// <summary>
    /// Primer abstraktnega razreda
    /// </summary>
    public abstract class ChessPiece : IMoveable
    {
        public ChessPiece(int weight, Color color)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public Color Color { get; }
        public int Weight { get; }
        public BoardField Position { get; set; }

        public abstract bool Move(BoardField finalPosition);

        public abstract string Name { get; }

        public override string ToString()
        {
            return $"Figura {this.Name} je na polju {this.Position}.";
        }

        public virtual bool SetStartPosition(BoardField field)
        {
            this.Position = new ChessBoardField(1, 1);
            return true;
        }
    }

    public class Queen : ChessPiece
    {
        public Queen(Color color) : base(9, color) { }

        public int Dummy { get; }

        public override bool Move(BoardField finalPosition)
        {
            this.Position = finalPosition;
            return true;
        }

        public override string Name
        {
            get
            {
                return "Dama";
            }
        }

        public override string ToString()
        {
            return $"FiguraQ {this.Name} je na polju {this.Position}.";
        }
    }


    public interface IMetaData
    {
        string Author { get; set; }
        DateTime DateCreated { get; }
        string? Organization { get; set; }
    }

    public interface IExample
    {
        // Funkcija z enakim podpisom, ki predstavlja avtorja ideje za npr. aplikacijo
        string Author { get; set; }
    }


    public class Application : IMetaData, IExample
    {
        string IMetaData.Author { get; set; }

        // Eksplicitna implementacija
        string IExample.Author { get; set; }

        public DateTime DateCreated { get; }

        public string? Organization { get; set; }

        
        public int RAMConsumption { get; set; }
        public string GetInstructions() { return "There are no instructions!"; }
     
        public Application(string authorMD, string authorEx)
        {
            ((IMetaData)this).Author = authorMD;
            ((IExample)this).Author = authorEx;
        }
    }

    public class File : IMetaData
    {
        public string Author { get; set; }

        public DateTime DateCreated { get; }

        public string? Organization { get; set; }

        public File(string author)
        {
            Author = author;
        }
    }

    public class Exhibition : IMetaData, IExample
    {
        public string Author { get; set; }

        public DateTime DateCreated { get; }

        public string? Organization { get; set; }

        public Exhibition(string author)
        {
            Author = author;
        }
    }
}

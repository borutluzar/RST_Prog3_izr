using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace RST_Prog3_izr
{
    public class ChessBoardField
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

    public abstract class Piece
    {
        public Piece(int weight, Color color)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public Color Color { get; }
        public int Weight { get; }
        public ChessBoardField Position { get; set; }

        public abstract bool Move(ChessBoardField finalPosition);

        public abstract string Name { get; }

        public override string ToString()
        {
            return $"Figura {this.Name} je na polju {this.Position}.";
        }
    }

    public class Queen : Piece
    {
        public Queen(Color color) : base(9, color)
        {

        }

        public int Dummy { get; }

        public override bool Move(ChessBoardField finalPosition)
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
}

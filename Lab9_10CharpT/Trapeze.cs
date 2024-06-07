using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CSharp
{
    internal class Trapeze
    {
        //поля
        private int a;
        private int b;
        private int h;
        private int c;

        //конструктори
        public Trapeze()
        {
            this.a = 3;
            this.b = 5;
            this.h = 2;
            this.c = 0;
        }

        public Trapeze(int osnova1, int osnova2, int height, int color)
        {
            this.a = osnova1;
            this.b = osnova2;
            this.h = height;
            this.c = color;
        }

        //get i set
        //public int A { get => this.a; set => this.a = value;}
        public int A
        {
            get { return this.a; }
            set { this.a = value; }
        }

        public int B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        public int H
        {
            get { return this.h; }
            set { this.h = value; }
        }

        public int C
        {
            get { return this.c; }
        }


        //методи
        public void DisplayLengths()
        {
            Console.WriteLine($"Base 1: {A}");
            Console.WriteLine($"Base 2: {B}");
            Console.WriteLine($"Height: {H}");
        }

        public double CalculatePerimeter()
        {
            double P = a + b + 2 * Math.Sqrt(Math.Pow((b - a) / 2, 2) + Math.Pow(h, 2));
            return P;
        }

        public double CalculateArea()
        {
            double S = ((double)this.a + this.b) / 2 * this.h;
            return S;
        }

        public bool IsSquare()
        {
            return this.a == this.b && this.a == this.h;
        }
    }
}
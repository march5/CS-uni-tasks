using System;
using System.Collections;
using System.Collections.Generic;

namespace task3
{
    class Program
    {
        class Rectangle
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }
            public int GetArea()
            {
                return Width * Height;
            }
        }
       
        class Square //3.1 nie dziedziczy się kwadrata po prostokącie, możemy ew stworzyć nową nadrzędną klasę abstrakcyjną po której będą dziedziczyć
            //klasy Square i Rectangle
        {
            public int Height
            {
                get => Height;
                set => Height = Width = value;
            }
            public int Width
            {
                get => Width;
                set => Width = Height = value;
            }

            public int GetArea()
            {
                return Width * Height;
            }
        }

        class Queue : ArrayList
        {
            public void Enqueue(Object value) 
            { 
                this.Add(value); 
            }

            public Object Dequeue() 
            {
                Object obj = this[0];

                this.RemoveAt(0);

                return obj;
            }
        }

        class CompositionQueue // 3.2 Queue na ArrayList przez kompozycję
        {
            ArrayList list = new ArrayList();

            public void Enqueue(Object value)
            {
                list.Add(value);
            }

            public Object Dequeue()
            {
                Object obj = list[0];
                list.RemoveAt(0);

                return obj;
            }
        }

        /* 3.3 W przypadku kolejki zrealizowanej przez kompozycje wystarczy zamiast ArrayListy stworzyć instancję tablicy we wnętrzu kolejki 
        i odpowiednio zaimplementować funkcje aby działały na zwykłej tablicy (przesuwanie w tablicy po Dequeue()
        Dziedziczenie po klasie array nie jest możliwe
        */

        //class ArrayQueue : Array { }

        //3.4

        public class Complex<T>
        {
            private T real;
            private T imaginary;

            public void SetReal(T value)
            {
                this.real = value;
            }

            public void SetIma(T value)
            {
                this.imaginary = value;
            }

            public T GetReal()
            {
                return this.real;
            }

            public T GetIma()
            {
                return this.imaginary;
            }

        }

        //3.5

        public class Matrix
        {
            public int w;
            public int h;
            public int[] values;

            public Matrix(int w, int h)
            {
                this.w = w;
                this.h = h;
                values = new int[w * h];
            }

            public int this[int i, int j]
            {
                get { return this.values[i * w + j]; }
                set { this.values[i * w + j] = value;  }
            }

            public static Matrix operator +(Matrix a, Matrix b)
            {
                if(a.w != b.w || a.h != b.h)
                {
                    Console.WriteLine("Wrong matrices sizes!");
                    return a;
                }

                var ret = new Matrix(a.w, a.h);

                for(int i = 0; i < a.values.Length; i++)
                {
                    ret.values[i] = a.values[i] + b.values[i];
                }

                return ret;
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                if(a.h != b.w)
                {
                    Console.WriteLine("Those matrices canot be multipied!");
                    return a;
                }
                var ret = new Matrix(a.w, b.h);
                int temp = 0;

                for(int i =0; i < a.w; i++)
                {
                    for(int j = 0; j < b.h; j++)
                    {
                        temp = 0;
                        for(int k = 0; k < a.h; k++)
                        {
                            temp += a[i, k] * b[k, j];
                        }
                        ret[i, j] = temp;
                    }
                }

                return ret;
            }
        }

        public class SquareMatrix : Matrix
        {
            public SquareMatrix(int a) : base(a, a)
            {
                /*this.w = a;
                this.h = a;
                this.values = new int[w * h];*/
            }

            public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b)
            {
                var ret = new SquareMatrix(a.w);

                for (int i = 0; i < a.values.Length; i++)
                {
                    ret.values[i] = a.values[i] + b.values[i];
                }

                return ret;
            }

            public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b)
            {
 
                var ret = new SquareMatrix(a.w);
                int temp = 0;

                for (int i = 0; i < a.w; i++)
                {
                    for (int j = 0; j < b.h; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < a.h; k++)
                        {
                            temp += a[i, k] * b[k, j];
                        }
                        ret[i, j] = temp;
                    }
                }

                return ret;
            }

            public bool isDiagonal()
            {
                for (int i = 0; i < this.w; i++)
                    for (int j = 0; j < this.w; j++)
                        if ((i != j) && (this.values[i * w + j] != 0))
                            return false;
                return true;
            }
        }



        static void Main(string[] args)
        {
            /*Complex<int> com = new Complex<int>();
            Complex<string> com2 = new Complex<string>();

            com.SetReal(4); com.SetIma(5);

            Console.WriteLine("Complex<int> " + com.GetReal() + " " + com.GetIma());

            com2.SetReal("four"); com2.SetIma("five");

            Console.WriteLine("Complex<string> " + com2.GetReal() + " " + com2.GetIma());*/

            SquareMatrix matrix = new SquareMatrix(3);
            SquareMatrix matrix2 = new SquareMatrix(3);

            for(int i = 0; i < 3; i++)
            {
                for(int j =0; j < 3; j++)
                {
                    matrix[i, j] = (j + 1) * (i + 1);
                    if (i == j)
                        matrix2[i, j] = 2;
                    else
                        matrix2[i, j] = 0;
                }
            }

            //matrix = matrix + matrix2;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(matrix2.isDiagonal());
        }
    }
}

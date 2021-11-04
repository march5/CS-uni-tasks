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
       
        class Square //3.1 nie dziedziczy się kwadrata po prostokącie
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
        //https://gist.github.com/klmr/314d05b66c72d62bd8a184514568e22f

        public class Matrix<T> where T : List<float>
        {
            private List<T> list;
            private readonly int width;
            private readonly int height;
            private static ICalculator<T> calculator;

            public Matrix(int w, int h)
            {
                this.width = w;
                this.height = h;
            }

            public virtual T this[int i, int j]
            {
                get { return list[i * width + j]; }
                set { list[i * width + j] = value; }
            }
            
            public virtual T GetAt(int i, int j)
            {
                return list[i*width + j];
            }

            public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
            {
                if (a.width != b.width || a.height != b.height) throw new ArgumentException("Matricies must have compatible dimensions");

                Matrix<T> re = new Matrix<T>(a.width, a.height);

                for(int i = 0; i < a.list.Count; i++)
                {
                    re.list[i] = calculator.Add(a.list[i], b.list[i]);
                }

                return re;
            }

            public interface ICalculator<T>
            {
                T Add(T a, T b);
                T Multiply(T a, T b);
            }

            class Calculator : ICalculator<float>
            {
                public float Add(float a, float b) { return a + b; }
                public float Multiply(float a, float b) { return a * b; }
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

            Matrix<List<float>> matrix = new Matrix<List<float>>(3,3);
            Matrix<List<float>> matrix2 = new Matrix<List<float>>(3, 3);

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    matrix[i, j] = 1f;
                }
            }

        }
    }
}

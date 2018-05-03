using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        public static void CheckNumber(out double k)
        {
            bool OK=false;
            do
            {
                OK = Double.TryParse(Console.ReadLine(), out k);
                if (OK == false) Console.WriteLine("Введено некорректное число!");
            } while (OK != true);
        }
        static int k = 0;
        static void Check(ref int kolvo, double E, int N, double elem1,double elem2,double elem3)
        {
            k++;
            double elem_new = elem1 / 3 + elem2 / 2 + elem3 * 2 / 3;
            if (Math.Abs(elem_new - elem1) < E)
            {
                kolvo++;
                Console.WriteLine(kolvo+") "+" "+elem_new+"; "+elem1);
            }
            if (k < N)
                Check(ref kolvo, E, N, elem_new, elem1, elem2);
        }
        static void Main(string[] args)
        {
            bool OK=false;
            double a1,a2,a3,E;
            int N;
            Console.WriteLine("Введите элемент a1: ");
            CheckNumber(out a1);
            Console.WriteLine("Введите элемент a2: ");
            CheckNumber(out a2);
            Console.WriteLine("Введите элемент a3: ");
            CheckNumber(out a3);
            Console.WriteLine("Введите число E: ");
            CheckNumber(out E);
            Console.WriteLine("Введите количество элементов последовательности N:");
            do
            {
                OK = Int32.TryParse(Console.ReadLine(), out N)&&N>0;
            } while (!OK);
            int kolvo=0;
            Check(ref kolvo, E, N, a1, a2, a3);
            Console.WriteLine("Количество пар: "+kolvo);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        //Проверка на ввод корректного вещественного числа 
        public static void CheckNumber(out double k)
        {
            bool OK=false;
            do
            {
                OK = Double.TryParse(Console.ReadLine(), out k);
                if (OK == false) Console.WriteLine("Введено некорректное число!");
            } while (OK != true);
        }
        static int k = 0;//Количество созданных элементов
        //Метод для получения количества пар, удовл. условию: | А(к) – А(к–1) | < E
        static void Check(ref int kolvo, double E, int N, double elem1,double elem2,double elem3)
            //kolvo - Текущее количество пар
            //E - число, меньше которого должна быть разность 2 элементов по модулю
            //N - кол-во генерируемых элементов
            //elem1 - A(k-1)
            //elem2 - A(k-2)
            //elem3 - A(k-3)
        {
            k++;
            //Создание элемента A(k)
            double elem_new = elem1 / 3 + elem2 / 2 + elem3 * 2 / 3;
            if (Math.Abs(elem_new - elem1) < E)//если | А(к) – А(к–1) | < E
                //То кол-во пар увел. на 1, пара выводится пользователю
            {
                kolvo++;
                Console.WriteLine(kolvo+") "+" "+(3+k)+"; "+(k+2));
            }
            //Если количество созданных пока что меньше N, то вызов этого же метода
            //Иначе выход из рекурсии
            if (k < N)
                Check(ref kolvo, E, N, elem_new, elem1, elem2);
        }
        static void Main(string[] args)
        {
            bool OK=true;
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
                if (!OK) Console.WriteLine("Требуется ввести натуральное число!");
                OK = Int32.TryParse(Console.ReadLine(), out N)&&N>0;
            } while (!OK);
            int kolvo=0;
            Check(ref kolvo, E, N, a3, a2, a1);
            Console.WriteLine("Количество пар: "+kolvo);
            Console.ReadLine();
        }
    }
}

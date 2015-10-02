using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uravnenie
{
    class Program
    {



        static void Main(string[] args)
        {

            int i = 0;
            string Ur = string.Empty; ;
            Read(ref Ur);
            Resolve(GetA(Ur, ref i), GetB(Ur, ref i), GetC(Ur, ref i));

            Console.ReadKey();

        }

        public static void Resolve(double a, double b, double c)
        {
            double d = ((b * b) - (4 * a * c));
            if ((d >= 0) & Math.Abs(d) > double.Epsilon)
            {
                double x1, x2;
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);


                Console.WriteLine("x1=" + x1 + " x2=" + x2);

            }

            else
            {
                Console.WriteLine("Действительных решений нет.");

            }


        }

        public static void ControlString(string Ur)
        {
            if (Ur.Length < 11) Console.WriteLine("Неверные входные данные.");
            int CountPlusMinus = 0;
            int CountRavno = 0;
            int CountX = 0;
            int CountGalka = 0;


            for (int i = 0; i < Ur.Length; i++)
            {
                if (Ur[i].ToString() == "+" || Ur[i].ToString() == "-") CountPlusMinus++;
                if (Ur[i].ToString() == "=") CountRavno++;
                if (Ur[i].ToString() == "x") CountX++;
                if (Ur[i].ToString() == "^") CountGalka++;

            }
            if (CountPlusMinus == 2 & CountRavno == 1 & CountX == 2 & CountGalka == 1) Console.WriteLine("Данные верны, ведутся расчёты.");
            else Console.WriteLine("Неверные входные данные.");
        }

        public static void Read(ref string Ur)
        {

            Console.WriteLine("Введите квадратное уравнение.");
            Ur = Console.ReadLine();
            ControlString(Ur);

        }

        public static double GetA(String Ur, ref int i)
        {
            double a = 0;
            for (; i < Ur.Length; i++)
            {
                if (Ur[i].ToString() == "x")
                {
                    a = double.Parse(Ur.Substring(0, i));
                    break;
                }

            }

            return a;
        }

        public static double GetB(String Ur, ref int i)
        {
            double b = 0;
            int Count = 0;
            for (i += 4; i < Ur.Length; i++)
            {

                if (Ur[i].ToString() == "x")
                {
                    b = double.Parse(Ur.Substring(i - 1, Count));
                    break;

                }
                Count++;
            }
            return b;
        }

        public static double GetC(String Ur, ref int i)
        {
            double c = 0;
            int Count = 0;
            for (i += 1; i < Ur.Length; i++)
            {

                if (Ur[i].ToString() == "=")
                {
                    c = double.Parse(Ur.Substring(i - 2, Count));
                    break;

                }
                Count++;
            }
            return c;
        }


    }
}

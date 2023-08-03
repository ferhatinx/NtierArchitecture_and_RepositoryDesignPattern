using System;

namespace _01.AsekronProgramlama
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(Toplam(5, 6, 7, 8, 9, 0, 0, 0, 9));
        }
        static double Toplam(params int[] sayilar)
        {
            double toplam = 0;
            foreach (int item in sayilar)
            {
                toplam += item;
            }
            return toplam;
        }
    }
}

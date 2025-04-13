 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_uvod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Primjer jednostavnog LINQ upita nad poljem prezimena gdje tražimo prezime: ");
            Console.WriteLine("====================================");

            string[] prezimena = { "Matić", "Ivić", "Tesla", "Katalinić", "Programerić" };

            var nasLinqUpit = from prezime in prezimena
                              where prezime.Contains("Ivić")
                              select prezime;

            foreach(var prezime in nasLinqUpit)
            {
                Console.Write(prezime + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("Primjer jednostavnog LINQ upita nad poljem imena gdje tražimo ime sa slovom t: ");
            Console.WriteLine("====================================");

            string[] imena = { "Ana", "Iva", "Katarina", "Marijana", "Anita", "Ivana", "Matilda"};

            var pronadjiImena = from ime in imena
                               where ime.Contains('t')
                               select ime;

            foreach(var ime in pronadjiImena)
            {
                Console.Write(ime + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("Primjer LINQ upita nad poljem brojeva gdje tražimo vraća samo pozitivne: ");
            Console.WriteLine("====================================");

            int[] brojevi = { 3, 5, 9, 1, -5, -10, 13, -34, 2, 6, -1, 0 };

            var pozitivniBrojevi = from broj in brojevi
                                    where broj > 0
                                    select broj;

 
            foreach (var broj in pozitivniBrojevi)
            {
                Console.Write(broj + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("Primjer LINQ upita nad poljem brojeva gdje tražimo vraća brojeve između -5 i 5: ");
            Console.WriteLine("====================================");

            var trazeniBrojevi = from broj in brojevi
                                 where broj >= -5 && broj <= 5
                                 select broj;

            foreach(var broj in trazeniBrojevi)
            {
                Console.Write(broj + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_provjeri_znakove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recenica;

            Console.Write("Unesite rečenicu: ");
            recenica = Console.ReadLine();
            Console.WriteLine();

            var PronadjiUcestalostZnakova = from x in recenica
                                            group x by x into y
                                            select y;

            Console.WriteLine("Učestalost znakova je: ");
            foreach(var stavka in PronadjiUcestalostZnakova)
            {
                Console.WriteLine("Znak "+stavka.Key+": "+stavka.Count());
            }
        }
    }
}

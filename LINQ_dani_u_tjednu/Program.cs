using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_dani_u_tjednu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daniUTjednu = {"Ponedjeljak", "Utorak", "Srijeda", "Četvrtak", "Petak",
                                        "Subota", "Nedjelja"};

            var dani = from dan in daniUTjednu select dan;

            foreach(var dan in dani)
            {
                Console.WriteLine(dan);
            }
        }
    }
}

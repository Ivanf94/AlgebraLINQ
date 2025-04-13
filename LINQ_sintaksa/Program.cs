using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_sintaksa
{
    class Polaznik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime {  get; set; }
        public int Starost { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] listaPolaznika =
            {
                new Polaznik(){ID=1, Ime="Ivo", Prezime="Programerić", Starost=18},
                new Polaznik(){ID=2, Ime="Ana", Prezime="Dizajnerić", Starost=21},
                new Polaznik(){ID=3, Ime="Marko", Prezime="Sistemovski", Starost=25},
                new Polaznik(){ID=4, Ime="Ana", Prezime="Programerić", Starost=20},
                new Polaznik(){ID=5, Ime="Ana Marija", Prezime="Matić", Starost=31},
                new Polaznik(){ID=6, Ime="Marko", Prezime="Stojanovski", Starost=17},
                new Polaznik(){ID=7, Ime="Marija", Prezime="Grbić", Starost=19}
            };

            Console.WriteLine("==================================================");
            Console.WriteLine("Primjer jednostavnog iteriranja kroz kolekciju.");
            Console.WriteLine("Zadatak: Naći polaznike između 12 i 20 godina starosti i pohraniti u polje 'polaznici'.");
            Console.WriteLine("==================================================");

            Polaznik[] polaznici = new Polaznik[10];

            int brojac = 0;
            foreach(Polaznik p in listaPolaznika)
            {
                if(p.Starost > 12 && p.Starost < 20)
                {
                    polaznici[brojac] = p;
                    brojac++;
                }
            }

            foreach(var p in polaznici)
            {
                if (p == null) continue;
                Console.WriteLine(p.ID+": "+p.Ime+" "+p.Prezime+", "+p.Starost);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("Gornji zadatak s LINQ upitom - Query syntax");
            Console.WriteLine("==================================================");

            polaznici = (from p in listaPolaznika
                        where p.Starost > 12 && p.Starost < 20
                        select p).ToArray();

            foreach (var p in polaznici)
            {
                if (p == null) continue;
                Console.WriteLine(p.ID + ": " + p.Ime + " " + p.Prezime + ", " + p.Starost);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("Gornji zadatak s LINQ upitom - Method syntax");
            Console.WriteLine("==================================================");

            polaznici = listaPolaznika.Where(p => p.Starost > 12 && p.Starost < 20).ToArray();

            foreach (var p in polaznici)
            {
                if (p == null) continue;
                Console.WriteLine(p.ID + ": " + p.Ime + " " + p.Prezime + ", " + p.Starost);
            }
        }
    }
}

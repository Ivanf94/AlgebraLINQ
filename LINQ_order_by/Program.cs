using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_order_by
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika =
{
                new Polaznik(){ID=1, Ime="Ivo", Prezime="Programerić", Starost=18},
                new Polaznik(){ID=2, Ime="Ana", Prezime="Dizajnerić", Starost=21},
                new Polaznik(){ID=3, Ime="Marko", Prezime="Sistemovski", Starost=25},
                new Polaznik(){ID=4, Ime="Ana", Prezime="Programerić", Starost=20},
                new Polaznik(){ID=5, Ime="Ana Marija", Prezime="Matić", Starost=31},
                new Polaznik(){ID=6, Ime="Marko", Prezime="Stojanovski", Starost=17},
                new Polaznik(){ID=7, Ime="Marija", Prezime="Grbić", Starost=19}
            };

            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy operator - sortiraj uzlazno");
            Console.WriteLine("==========================================================");

            var sortiraj_uzlazno = from p in ListaPolaznika
                                   orderby p.Prezime
                                   select p;

            foreach(var rez in sortiraj_uzlazno)
            {
                Console.WriteLine(rez.Prezime+" "+rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy operator - sortiraj silazno");
            Console.WriteLine("==========================================================");

            var sortiraj_silazno = from p in ListaPolaznika
                                   orderby p.Prezime descending
                                   select p;

            foreach (var rez in sortiraj_silazno)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy operator - sortiraj uzlazno method syntax stil");
            Console.WriteLine("==========================================================");

            var sortiraj_uzlazno_skraceno = ListaPolaznika.OrderBy(p => p.Prezime);

            foreach (var rez in sortiraj_uzlazno_skraceno)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy operator - sortiraj silazno method syntax stil");
            Console.WriteLine("==========================================================");

            var sortiraj_silazno_skraceno = ListaPolaznika.OrderByDescending(p => p.Prezime);

            foreach (var rez in sortiraj_silazno_skraceno)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy operator - višestruko sortiranje");
            Console.WriteLine("==========================================================");

            var sortiraj_visestruko = from p in ListaPolaznika
                                      orderby p.Prezime, p.Ime, p.Starost
                                      select p;

            foreach (var rez in sortiraj_visestruko)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy i ThenBy operator - uzlazno višestruko sortiranje");
            Console.WriteLine("==========================================================");

            var sortiraj_visestruko_uzlazno = ListaPolaznika.OrderBy(p => p.Ime).ThenBy(p => p.Prezime);

            foreach (var rez in sortiraj_visestruko_uzlazno)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ OrderBy i ThenBy operator - silazno višestruko sortiranje");
            Console.WriteLine("==========================================================");

            var sortiraj_visestruko_silazno = ListaPolaznika.OrderBy(p => p.Prezime).ThenByDescending(p => p.Ime).ThenBy(p => p.Starost);

            foreach (var rez in sortiraj_visestruko_silazno)
            {
                Console.WriteLine(rez.Prezime + " " + rez.Ime);
            }
        }
        public class Polaznik
        {
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int Starost { get; set; }
        }
    }
}

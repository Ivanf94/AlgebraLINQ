using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_group_i_lookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika =
            {
                new Polaznik(){ID=1, Ime="Ivo", Prezime="Programerić", Starost=18},
                new Polaznik(){ID=2, Ime="Ana", Prezime="Dizajnerić", Starost=21},
                new Polaznik(){ID=3, Ime="Marko", Prezime="Sistemovski", Starost=21},
                new Polaznik(){ID=4, Ime="Ana", Prezime="Programerić", Starost=18},
                new Polaznik(){ID=5, Ime="Ana Marija", Prezime="Matić", Starost=21},
                new Polaznik(){ID=6, Ime="Marko", Prezime="Stojanovski", Starost=18},
                new Polaznik(){ID=7, Ime="Marija", Prezime="Grbić", Starost=18}
            };

            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ GroupBy operator - grupiranje po starosti");
            Console.WriteLine("==========================================================");

            var grupiraj_po_starosti = from p in ListaPolaznika
                                       group p by p.Starost;

            foreach (var grupa_starosti in grupiraj_po_starosti)
            {
                Console.WriteLine("Grupa starosti od {0} godina: ", grupa_starosti.Key);

                foreach(var p in grupa_starosti)
                {
                    Console.WriteLine(p.Prezime+" "+p.Ime);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ GroupBy operator - grupiranje po starosti method syntax stil");
            Console.WriteLine("==========================================================");

            var grupiraj_po_starosti_skraceno = ListaPolaznika.GroupBy(p => p.Starost);

            foreach (var grupa_starosti in grupiraj_po_starosti_skraceno)
            {
                Console.WriteLine("Grupa starosti od {0} godina: ", grupa_starosti.Key);

                foreach (var p in grupa_starosti)
                {
                    Console.WriteLine(p.Prezime + " " + p.Ime);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ ToLookup operator - grupiranje po starosti method syntax stil");
            Console.WriteLine("==========================================================");

            var grupiraj_s_lookup = ListaPolaznika.ToLookup(p => p.Starost);

            foreach (var grupa_starosti in grupiraj_s_lookup)
            {
                Console.WriteLine("Grupa starosti od {0} godina: ", grupa_starosti.Key);

                foreach (var p in grupa_starosti)
                {
                    Console.WriteLine(p.Prezime + " " + p.Ime);
                }
            }
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

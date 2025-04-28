using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_group_join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Polaznik> ListaPolaznika = new List<Polaznik>
            {
                new Polaznik(){ID=1, Ime="Ivo", Prezime="Programerić", TecajID=1},
                new Polaznik(){ID=2, Ime="Ana", Prezime="Dizajnerić", TecajID=1},
                new Polaznik(){ID=3, Ime="Marko", Prezime="Sistemovski", TecajID=3},
                new Polaznik(){ID=4, Ime="Ana", Prezime="Programerić", TecajID=2},
                new Polaznik(){ID=5, Ime="Ana Marija", Prezime="Matić", TecajID=2},
                new Polaznik(){ID=6, Ime="Marko", Prezime="Stojanovski", TecajID=1},
                new Polaznik(){ID=7, Ime="Marija", Prezime="Grbić"}
            };

            List<Tecaj> ListaTecajeva = new List<Tecaj>()
            {
                new Tecaj(){ID=1, Naziv="Programiranje C#"},
                new Tecaj(){ID=2, Naziv="Web design"},
                new Tecaj(){ID=3, Naziv="SQL"}
            };

            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ GroupJoin operator - method syntax");
            Console.WriteLine("====================================================");

            var ms_group_join = ListaTecajeva.GroupJoin(ListaPolaznika, t => t.ID, p => p.TecajID,
                                (t, grupaPolaznika) => new
                                {
                                    Polaznici = grupaPolaznika,
                                    Naziv_tecaja=t.Naziv,
                                });

            foreach(var stavka in ms_group_join)
            {
                Console.WriteLine(stavka.Naziv_tecaja);
                foreach(var polaznik in stavka.Polaznici)
                {
                    Console.WriteLine(polaznik.Ime+" "+polaznik.Prezime);
                }
                Console.WriteLine("==============");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ GroupJoin operator - query syntax");
            Console.WriteLine("====================================================");

            var qs_group_join = from t in ListaTecajeva
                                join p in ListaPolaznika
                                on t.ID equals p.TecajID into grupaPolaznika
                                select new
                                {
                                    Polaznici = grupaPolaznika,
                                    Naziv_tecaja = t.Naziv
                                };

            foreach (var stavka in qs_group_join)
            {
                Console.WriteLine(stavka.Naziv_tecaja);
                foreach (var polaznik in stavka.Polaznici)
                {
                    Console.WriteLine(polaznik.Ime + " " + polaznik.Prezime);
                }
                Console.WriteLine("==============");
            }
        }
    }
    public class Polaznik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int TecajID { get; set; }
    }

    public class Tecaj
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}

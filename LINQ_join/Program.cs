using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<string> stringLista1 = new List<string>()
            {
                "Jedan",
                "Dva",
                "Tri",
                "Četiri"
            };

            IList<string> stringLista2 = new List<string>
            {
                "Jedan",
                "Dva",
                "Pet",
                "Šest"
            };

            Console.WriteLine("===================================================");
            Console.WriteLine("LINQ join operator - samopodudarne vrijednosti");
            Console.WriteLine("===================================================");

            var podudarne_vrijednosti = stringLista1.Join(stringLista2, str1 => str1, str2 => str2,
                (str1, str2) => str1);

            foreach(var rez in podudarne_vrijednosti)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine("LINQ join operator - join s različitim klasama method syntax");
            Console.WriteLine("===================================================");

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

            var ms_inner_join = ListaPolaznika.Join(ListaTecajeva, p => p.TecajID, t => t.ID,
                                (p, t) => new
                                {
                                    Ime = p.Ime,
                                    Prezime = p.Prezime,
                                    Naziv_tecaja = t.Naziv
                                });

            foreach(var rez in ms_inner_join)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine("LINQ join operator - join s različitim klasama query syntax");
            Console.WriteLine("===================================================");

            var qs_inner_join = from p in ListaPolaznika
                                join t in ListaTecajeva on p.TecajID equals t.ID
                                select new
                                {
                                    Ime = p.Ime,
                                    Prezime = p.Prezime,
                                    Naziv_tecaja = t.Naziv
                                };

            foreach(var rez in qs_inner_join) {  Console.WriteLine(rez);}
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

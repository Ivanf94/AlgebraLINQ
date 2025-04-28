using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Polaznik> ListaPolaznika = new List<Polaznik>()
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
            Console.WriteLine("LINQ select operator - samo ime i prezime query syntax");
            Console.WriteLine("==========================================================");

            var qs_samo_ime_prezime = from p in ListaPolaznika select p.Ime + " " + p.Prezime;

            foreach(var stavka in qs_samo_ime_prezime) Console.WriteLine(stavka);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ select operator - s anonimnim tipom rezultata query syntax");
            Console.WriteLine("==========================================================");

            var sq_s_anonimnim_tipom = from p in ListaPolaznika
                                       select new
                                       {
                                           Polaznik = p.Ime + " " + p.Prezime, Godine = p.Starost
                                       };

            foreach(var s in sq_s_anonimnim_tipom) {  Console.WriteLine(s); }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ select operator - s anonimnim tipom rezultata method syntax");
            Console.WriteLine("==========================================================");

            var ms_s_anonimnim_tipom = ListaPolaznika.Select(p => new
            {
                Polaznik = p.Ime + " " + p.Prezime,
                Godine = p.Starost
            });

            foreach (var s in ms_s_anonimnim_tipom) { Console.WriteLine(s); }

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

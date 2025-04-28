using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_agregacije
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

            List<string> ListaStringova = new List<string>() { "Jedan", "Dva", "Tri", "Četiri", "Pet" };

            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Aggregate operator");
            Console.WriteLine("================================================");

            var string_odvojen_zarezom = ListaStringova.Aggregate((s1, s2) => s1 + ", " + s2);
            Console.WriteLine(string_odvojen_zarezom);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Aggregate operator sa Seed value metodom preopterećivanja");
            Console.WriteLine("================================================");

            string imena_polaznika_odvojena_zarezom = ListaPolaznika.Aggregate<Polaznik, string>(
                "Imena i prezimena polaznika: ", (str, p) => str += p.Ime + " " + p.Prezime + ", ");
            Console.WriteLine(imena_polaznika_odvojena_zarezom);
            //= kod str += p.Ime... je bespotrebno

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Aggregate operator sa Seed value metodom preopterećivanja, bez zadnjeg zareza");
            Console.WriteLine("================================================");

            string imena_polaznika_odvojena_zarezom_2 = ListaPolaznika.Aggregate<Polaznik, string, string>(
                String.Empty,
                (str, p) => str += p.Ime + " " + p.Prezime + ", ",
                str => str.Substring(0, str.Length - 2));
            Console.WriteLine(imena_polaznika_odvojena_zarezom_2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Average s jednostavnim tipovima");
            Console.WriteLine("================================================");

            List<int> ListaBrojeva = new List<int>() { 10, 13, 17, 36, 69, 32, 667 };

            var prosjek_brojeva = ListaBrojeva.Average();
            Console.WriteLine("Prosjek brojeva: " + prosjek_brojeva);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Average sa složenim tipovima");
            Console.WriteLine("================================================");

            var prosjek_godina = ListaPolaznika.Average(p => p.Starost);
            Console.WriteLine("Prosjek godina: " + prosjek_godina);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Count s jednostavnim tipovima");
            Console.WriteLine("================================================");

            var prebroji_sve = ListaBrojeva.Count();
            Console.WriteLine("Kolekcija ima " + prebroji_sve + " brojeva u sebi");

            var parni_brojevi = ListaBrojeva.Count(i => i % 2 == 0);
            Console.WriteLine("Kolekcija ima "+parni_brojevi+" parnih brojeva u sebi");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Count sa složenim tipovima");
            Console.WriteLine("================================================");

            var prebroji_polaznike = ListaPolaznika.Count();
            Console.WriteLine("Ukupno polaznika: "+prebroji_polaznike);

            var punoljetni_polaznici = ListaPolaznika.Count(p => p.Starost >= 18);
            Console.WriteLine("Punoljetnih polaznika: "+punoljetni_polaznici);

            var punoljetni_mqs = (from p in ListaPolaznika select p.Starost).Count(s => s > 18);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Min i Max s jednostavnim tipovima");
            Console.WriteLine("================================================");

            var najveci_broj = ListaBrojeva.Max();
            var najmanji_broj = ListaBrojeva.Min();

            Console.WriteLine("Najmanji je "+najmanji_broj+" ,a najveći je "+najveci_broj);

            var najveci_parni_broj = ListaBrojeva.Max(i =>
            {
                if (i % 2 == 0) return i;
                return 0;
            });

            Console.WriteLine("Najveći parni element je "+najveci_parni_broj);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("LINQ Min i Max sa složenim tipovima");
            Console.WriteLine("================================================");
        }
    }
    public class Polaznik : IComparable<Polaznik>
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Starost { get; set; }

        public int CompareTo(Polaznik other)
        {
            if (this.Prezime.Length >= other.Prezime.Length) return 1;
            return 0;
        }
    }
}

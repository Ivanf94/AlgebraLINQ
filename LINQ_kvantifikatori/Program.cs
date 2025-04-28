using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_kvantifikatori
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

            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ All operator");
            Console.WriteLine("====================================================");

            bool provjeri_ako_su_svi_tinejdzeri = ListaPolaznika.All(p => p.Starost > 12 && p.Starost < 20);
            Console.WriteLine(provjeri_ako_su_svi_tinejdzeri);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Any operator");
            Console.WriteLine("====================================================");

            bool provjeri_ako_su_neki_tinejdzeri = ListaPolaznika.Any(p => p.Starost > 12 && p.Starost < 20);
            Console.WriteLine(provjeri_ako_su_neki_tinejdzeri);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Contains operator");
            Console.WriteLine("====================================================");

            IList<int> ListaBrojeva = new List<int>() { 1, 2, 3, 4, 5 };
            bool postoji_li_10 = ListaBrojeva.Contains(10);
            Console.WriteLine(postoji_li_10);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Contains operator s klasom - neispravan način");
            Console.WriteLine("====================================================");

            Polaznik nas_polaznik = new Polaznik() { ID = 3, Ime = "Marko", Prezime = "Sistemovski", Starost = 25 };
            bool postoji_li_nas_polaznik = ListaPolaznika.Contains(nas_polaznik);
            Console.WriteLine(postoji_li_nas_polaznik);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Contains operator s klasom - ispravan način");
            Console.WriteLine("====================================================");

            bool provjeri_opet_naseg_polaznika = ListaPolaznika.Contains(nas_polaznik, new UsporedbaPolaznika());
            Console.WriteLine(provjeri_opet_naseg_polaznika);
        }
    }
    public class Polaznik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Starost { get; set; }
    }

    class UsporedbaPolaznika : IEqualityComparer<Polaznik>
    {
        public bool Equals(Polaznik x, Polaznik y)
        {
            if(x.ID == y.ID && x.Prezime == y.Prezime && x.Ime == y.Ime && x.Starost == y.Starost) return true;
            return false;
        }

        public int GetHashCode(Polaznik obj)
        {
            return obj.GetHashCode();
        }
    }
}

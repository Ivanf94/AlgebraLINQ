using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_where
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

            Console.WriteLine("=================================================");
            Console.WriteLine("LINQ Where operator - query syntax stil: ");
            Console.WriteLine("=================================================");

            var filtriraj_rezultat = from p in ListaPolaznika
                                     where p.Starost > 12 && p.Starost < 20
                                     select p.Ime + " " + p.Prezime;

            foreach(var rez in filtriraj_rezultat)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Where operator - Func tip delegata s anonimnom metodom: ");
            Console.WriteLine("====================================================");

            Func<Polaznik, bool> jeTinejdzer = delegate (Polaznik p)
            {
                return p.Starost > 12 && p.Starost < 20;
            };

            var filtriraj_rezultat_s_delegatom = from p in ListaPolaznika
                                                 where jeTinejdzer(p)
                                                 select p.Ime + " " + p.Prezime;

            foreach(var rez in filtriraj_rezultat_s_delegatom)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Where operator - koristi vanjsku metodu: ");
            Console.WriteLine("====================================================");

            var filtriraj_rezultat_s_metodom = from p in ListaPolaznika
                                               where ProvjeriAkoJeTinejdzer(p)
                                               select p.Ime + " " + p.Prezime;

            foreach(var rez in filtriraj_rezultat_s_metodom)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Where operator - method syntax stil: ");
            Console.WriteLine("====================================================");

            var filtriraj_rezultat_skraceno = ListaPolaznika.Where(p => p.Starost > 12 && p.Starost < 20);

            foreach(var rez in filtriraj_rezultat_skraceno)
            {
                Console.WriteLine(rez.Ime+" "+rez.Prezime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Where operator - method syntax stil s uvjetom: ");
            Console.WriteLine("====================================================");

            var filtriraj_rezultat_s_uvjetom = ListaPolaznika.Where((p, i) =>
            {
                if (i % 2== 0) return true;
                return false;
            });

            foreach (var rez in filtriraj_rezultat_s_uvjetom)
            {
                Console.WriteLine(rez.Ime + " " + rez.Prezime);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("LINQ Where operator - višestruki where: ");
            Console.WriteLine("====================================================");

            var filtriraj_rezultat_visestruko_1 = from p in ListaPolaznika
                                                  where p.Starost > 12
                                                  where p.Starost < 20
                                                  select p;

            foreach (var rez in filtriraj_rezultat_visestruko_1)
            {
                Console.WriteLine(rez.Ime + " " + rez.Prezime);
            }
            Console.WriteLine();
            Console.WriteLine();

            var filtriraj_rezultat_visestruko_2 = ListaPolaznika.Where(p => p.Starost > 12).Where(p => p.Starost < 20);

            foreach (var rez in filtriraj_rezultat_visestruko_2)
            {
                Console.WriteLine(rez.Ime + " " + rez.Prezime);
            }
        }

        public static bool ProvjeriAkoJeTinejdzer(Polaznik p)
        {
            return p.Starost > 12 && p.Starost < 20;
        }

    }

    public class Polaznik
    {
        public int ID {  get; set; }
        public string Ime { get; set; }
        public string Prezime {  get; set; }
        public int Starost { get; set; }
    }
}

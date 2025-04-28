using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_razni_primjeri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ListaVoca = new List<string>() { "Limun", "Jabuka", "Naranča", "Banana", "Limeta", "Lubenica", "Borovnica", "Kiwi", "Mango", "Kruška" };

            IEnumerable<string> VoceSaSlovomL = from voce in ListaVoca
                                                where voce[0] == 'L'
                                                select voce;

            IEnumerable<string> VoceSaSlovomL2 = ListaVoca.Where(v => v[0] == 'L');

            foreach(string v in VoceSaSlovomL)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();
            Console.WriteLine();

            List<int> NasumicniBrojevi = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 56, 54, 48, 4, 69, 49, 96
            };

            var Visekratnici4I6 = NasumicniBrojevi.Where(n => n % 4 == 0 || n % 6 == 0).ToList();
            foreach(int broj in Visekratnici4I6)
            {
                Console.WriteLine(broj);
            }

            Console.WriteLine();
            Console.WriteLine();

            List<Klijent> ListaKlijenata = new List<Klijent>() 
            { 
                new Klijent() { Ime = "Mićo", Prezime = "Programerić", Stanje=80345.66, Banka="Erste" },
                new Klijent() { Ime = "Ana", Prezime = "Dizajnerić", Stanje=9284756.21, Banka="ZABA" },
                new Klijent() { Ime = "Marko", Prezime = "Sistemovski", Stanje=487233.01, Banka="PBZ" },
                new Klijent() { Ime = "Ive Pavlo", Prezime = "Marić", Stanje=7001449.92, Banka="PBZ" },
                new Klijent() { Ime = "Ana", Prezime = "Katić", Stanje=790872.12, Banka="Erste" },
                new Klijent() { Ime = "Gandalf", Prezime = "Bjelobradi", Stanje=8374892.54, Banka="PBZ" },
                new Klijent() { Ime = "Oto", Prezime = "Marić", Stanje=957436.39, Banka="ZABA" },
                new Klijent() { Ime = "Sara", Prezime = "Ivić", Stanje=56562389.85, Banka="ZABA" },
                new Klijent() { Ime = "Kristian", Prezime = "Kristić", Stanje=1000000.00, Banka="Erste" },
                new Klijent() { Ime = "Pingvin", Prezime = "Madagaskarić", Stanje=10049528.68, Banka="Erste" }

            };

            var GrupirajPremaBanciMilijunase = ListaKlijenata.Where(k => k.Stanje >= 1000000).GroupBy(
                    p => p.Banka,
                    p=>p.Prezime+" "+p.Ime,
                    (banka, milijunas) => new GrupiraniMilijunasi()
                    {
                        Banka = banka,
                        Milijunasi = milijunas
                    }
                    ).ToList();

            foreach(var stavka in GrupirajPremaBanciMilijunase)
            {
                Console.WriteLine($"{stavka.Banka}: {string.Join(" i ", stavka.Milijunasi)}");
            }

            Console.WriteLine();
            Console.WriteLine();

            List<Banka> banke = new List<Banka>()
            {
                new Banka(){Naziv="Erste&Steiermarkische Bank",Simbol="Erste"},
                new Banka(){Naziv="Zagrebačka Banka", Simbol="ZABA"},
                new Banka(){Naziv="Privredna banka Zagreb", Simbol="PBZ"}
            };

            List<Klijent> IzvjestajMilijunasa = ListaKlijenata.Where(m => m.Stanje >= 1000000)
                .Select(m => new Klijent()
                {
                    Ime = m.Ime,
                    Prezime = m.Prezime,
                    Banka = banke.Find(b => b.Simbol == m.Banka).Naziv,
                    Stanje = m.Stanje,
                }).ToList();

            foreach(Klijent k in IzvjestajMilijunasa)
            {
                Console.WriteLine($"{k.Ime} {k.Prezime} je u {k.Banka}");
            }
        }
    }

    public class Banka
    {
        public string Simbol { get; set; }
        public string Naziv { get; set; }
    }

    public class Klijent
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public double Stanje { get; set; }
        public string Banka {  get; set; }
    }

    public class GrupiraniMilijunasi
    {
        public string Banka { get; set; }
        public IEnumerable<string> Milijunasi { get; set; }
    }
}

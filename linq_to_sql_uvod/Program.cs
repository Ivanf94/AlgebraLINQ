using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace linq_to_sql_uvod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.
                ConnectionStrings["linq_to_sql_uvod.Properties.Settings.linq_to_sqlConnectionString"].
                ConnectionString;

            LinqToSqlDataContext baza_podataka = new LinqToSqlDataContext(connStr);

            Console.WriteLine("=========================================================");
            Console.WriteLine("Unos zaposlenika s LINQ to SQL metodom: ");
            Console.WriteLine("=========================================================");

            UnosNovogZaposlenika(baza_podataka);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=========================================================");
            Console.WriteLine("Ažuriranje zaposlenika s LINQ to SQL metodom: ");
            Console.WriteLine("=========================================================");

            AzurirajZaposlenika(baza_podataka, 2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=========================================================");
            Console.WriteLine("Brisanje zaposlenika s LINQ to SQL metodom: ");
            Console.WriteLine("=========================================================");

            BrisanjeZaposlenika(baza_podataka, baza_podataka.Zaposleniks.Max(z=>z.ID));
        }

        static void UnosNovogZaposlenika(LinqToSqlDataContext baza)
        {
            Zaposlenik novi_zaposlenik = new Zaposlenik();
            novi_zaposlenik.ImePrezime = "Nikola Tesla";
            novi_zaposlenik.Email = "nikola.tesla@tesla.com";
            novi_zaposlenik.Telefon = "0987654321";
            novi_zaposlenik.Adresa = "New York bb";
            novi_zaposlenik.OdjelID = 4;

            baza.Zaposleniks.InsertOnSubmit(novi_zaposlenik);

            baza.SubmitChanges();

            Zaposlenik z = baza.Zaposleniks.FirstOrDefault(zap => zap.ImePrezime.Contains("Tesla"));

            Console.WriteLine($"{z.ID}: {z.ImePrezime}, {z.Email}, {z.Telefon}, {z.Adresa}");
        }

        static void AzurirajZaposlenika(LinqToSqlDataContext baza, int id_zaposlenika)
        {
            Zaposlenik azurirani_zaposlenik = baza.Zaposleniks.FirstOrDefault(zap=>zap.ID==id_zaposlenika);
            if(azurirani_zaposlenik == null)
            {
                Console.WriteLine($"Zaposlenik s ID-em {id_zaposlenika} nije nađen!");
                return;
            }

            azurirani_zaposlenik.ImePrezime = "Ažurirani zaposlenik";
            azurirani_zaposlenik.Email = "azuran@zaposlenik.com";
            azurirani_zaposlenik.Telefon = "0991234567";
            azurirani_zaposlenik.Adresa = "Adresni put bb";
            azurirani_zaposlenik.OdjelID = 2;

            baza.SubmitChanges();

            Zaposlenik z = baza.Zaposleniks.FirstOrDefault(zap => zap.ID == id_zaposlenika);

            Console.WriteLine($"{z.ID}: {z.ImePrezime}, {z.Email}, {z.Telefon}, {z.Adresa}");
        }

        static void BrisanjeZaposlenika(LinqToSqlDataContext baza, int id_zaposlenika)
        {
            Zaposlenik brisi_zaposlenika = baza.Zaposleniks.FirstOrDefault(zap => zap.ID == id_zaposlenika);
            if (brisi_zaposlenika == null)
            {
                Console.WriteLine($"Zaposlenik s ID-em {id_zaposlenika} ne postoji pa ne može biti obrisan!");
                return;
            }

            baza.Zaposleniks.DeleteOnSubmit(brisi_zaposlenika);

            baza.SubmitChanges();

            var listaZaposlenika = baza.Zaposleniks;
            foreach(var z in listaZaposlenika)
            {
                Console.WriteLine($"{z.ID}: {z.ImePrezime}, {z.Email}, {z.Telefon}, {z.Adresa}");
            }
        }
    }
}

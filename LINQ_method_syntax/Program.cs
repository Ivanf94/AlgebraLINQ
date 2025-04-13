using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_method_syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> brojevi = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var moji_brojevi = brojevi.Where(broj => broj < 5 || broj > 7);

            foreach (var broj in moji_brojevi)
            {
                Console.Write(broj + "  ");
            }

            Console.WriteLine();
            Console.WriteLine();

            List<string> kucni_ljubimci = new List<string>()
            {
                "Ovo je moj pas",
                "Ime mog psa je 'Mala'",
                "Ovo je moja zmija",
                "Zmija se zove Hera"
            };

            var pretraga = kucni_ljubimci.Where(z => z.Contains("pas"));

            foreach (var z in pretraga)
            {
                Console.WriteLine(z + "  ");
            }
        }
    }
}

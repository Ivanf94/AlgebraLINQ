using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_query_syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> brojevi = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            IEnumerable<int> moji_brojevi = from broj in brojevi
                                            where broj < 5 || broj > 7
                                            select broj;

            foreach(var broj in moji_brojevi)
            {
                Console.Write(broj + ", ");
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

            var pretraga = from tekst in kucni_ljubimci
                     where tekst.Contains("je")
                     select tekst;

            foreach(var tekst in pretraga)
            {
                Console.WriteLine(tekst+ ", ");
            }
        }
    }
}

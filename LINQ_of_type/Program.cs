using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_of_type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList MjesovitaLista = new ArrayList();
            MjesovitaLista.Add(0);
            MjesovitaLista.Add("Jedan");
            MjesovitaLista.Add("Dva");
            MjesovitaLista.Add(3);
            MjesovitaLista.Add(new Polaznik() { ID = 1, Ime = "Mato" });

            Console.WriteLine("======================================================================");
            Console.WriteLine("Primjer korištenja LINQ OfType operatora - Pronađi string tipove");
            Console.WriteLine("======================================================================");

            var string_rezultat = from s in MjesovitaLista.OfType<string>()
                                  select s;

            foreach(var rez in string_rezultat)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("======================================================================");
            Console.WriteLine("Primjer korištenja LINQ OfType operatora - Pronađi int tipove");
            Console.WriteLine("======================================================================");

            var int_rezultat = from s in MjesovitaLista.OfType<int>()
                               select s;

            foreach (var rez in int_rezultat)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("======================================================================");
            Console.WriteLine("Primjer korištenja LINQ OfType operatora - string s method syntax stilom");
            Console.WriteLine("======================================================================");

            var string_rezultat_skraceno = MjesovitaLista.OfType<string>();

            foreach (var rez in string_rezultat_skraceno)
            {
                Console.WriteLine(rez);
            }
        }
    }

    class Polaznik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
    }
}

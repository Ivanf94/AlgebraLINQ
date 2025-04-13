using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_pronadji_vece_brojeve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int ListaBrojeva, x, y;

            List<int> tempLista = new List<int>();
            Console.Write("Koliko brojeva želite unijeti: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for(i=0;i < x; i++)
            {
                Console.Write("Broj {0}: ", i + 1);
                ListaBrojeva=int.Parse(Console.ReadLine());
                tempLista.Add(ListaBrojeva);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Unesite broj koji će provjeriti prethodne vrijednosti i vratiti samo one veće: ");
            y = int.Parse(Console.ReadLine());

            var FiltrirajListu = tempLista.FindAll(j => j > y);

            Console.WriteLine("Brojevi veći od "+ y + " su: ");
            foreach(var broj in FiltrirajListu)
            {
                Console.WriteLine(broj);
            }
        }
    }
}

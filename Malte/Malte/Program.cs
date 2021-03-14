using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impfstoff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Haben Wir noch Impfstoff da? (1 oder 0)");
            Console.WriteLine("Anzahl an vorhandenen Impfstoff angeben:");
            int Impfstoff = Convert.ToInt32(Console.ReadLine());

            if (Impfstoff == 0)
            {
                Console.WriteLine("Keinen mehr?");
            } 
            else
            {
                Console.WriteLine("Einen noch?");
            }

            Console.WriteLine("Hast du einen genommen? (Ja oder Nein)");
            string frage = Console.ReadLine(); 

            if (frage == "Ja")

            {
                Console.WriteLine("Hast du?");
                Console.WriteLine("Ey er ist voll der Boris geworden.");
            }
            else
            {
                Console.WriteLine("Omg, voll gut!");
            }
            
            Console.ReadKey();
        }
    }
}
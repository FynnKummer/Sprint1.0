#using System;
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
            Console.WriteLine("Haben Wir noch Impfstoff da?");
            Console.WriteLine("Anzahl an vorhandenen Impfstoff angeben:");
            int Impfstoff = Convert.ToInt32(Console.ReadLine());        //Eingabe als Zahl konvertieren
            Console.WriteLine(Impfstoff + " noch?");
            Console.WriteLine("Hast du einen genommen? (Ja oder Nein)");
            string frage = Console.ReadLine(); 


            if (frage == "Ja"||"Test")
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
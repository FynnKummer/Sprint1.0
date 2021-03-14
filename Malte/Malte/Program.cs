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


<<<<<<< HEAD
            if (frage == "Ja"||"hi")
=======

            if (frage == "Ja"||"spongebob")
>>>>>>> d9ee55c2874c68eb2aed8644d0fb148c25fcf8d1

   

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
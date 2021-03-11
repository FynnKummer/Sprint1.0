using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wie alt ist Sie?: ");
            int alter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sie ist: " + alter);

            if (alter >= 18)
            {
                Console.WriteLine("Gönn dia Bruda");
            }
            else
            {
                Console.WriteLine("Bruda, du krigst Anseige");
            }
            Console.ReadLine();
        }
    }
}
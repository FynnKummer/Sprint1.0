using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1
{
    class Program
    {
        public static double schraubkopf(String form, int schluessel)
        {

            if (form == "I"||form=="i")       //Abfrage ob es sich um Außensechskant oder Innensechskant handelt
            {                                   
                                                
                                                
            }                                   
            else if (form == "A"||form=="a")    
            {                                   
               
                
            }
            else                            //Für den Fall einer Fehlerhaften eingabe 
            { 
                Console.WriteLine("Fehlerhafte Eingabe. Starten Sie das Programm neu");
            }
            return 1;

        }
        public static double gewinde(String[] gew)
        {


            return 1;
        }



        public static double Preis(double gewicht,int material int gewindeart, int gewinde, int gewindelänge, int schraubenkopf )
        {

           double preis = 0;
           double kilopreis; 

            if (material = 0)
            {
                kilopreis = 7.12 
            }
            else if (material = 1)
            {
                kilopreis = 16,78
            }
           preis = gewicht * kilopreis 


        }

        public static double festigkeit()
        {
            //hier den Code reinschreiben
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird

            return 1;
        }

        public static double masse()
        {
            //hier den Code reinschreiben
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird

            return 1; 
        }


        static void Main(string[] args)
        {
            int schluesselbreite;
            double material;
            String[] gewinde;


// Methode Schraubkopf

           

            //Methode Gewinde




            //Methode Preis




            //Methode Festigkeit




            //Methode Masse





            //Ende
            Console.WriteLine("Geben Sie bitte die gewünschte Länge der Schraube in mm ein");
            int schraube_laenge =Convert.ToInt32(Console.ReadLine());

            
            
            Console.ReadKey();






                   









        }
    }
}

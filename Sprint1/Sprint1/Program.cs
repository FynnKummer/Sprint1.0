using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1
{
    class Program
    {
       
        public static String kopftest()
        {
            String typ="";
            for (int i = 0; i == 0;)
            {
                typ = Console.ReadLine();

                if (typ == "A" || typ == "a" || typ == "I" || typ == "i")//Wenn die Eingabe für unseren FAll zulässig ist
                {
                    Console.WriteLine("Eingbe erfolgreich");
                    break;                                                 //Endlosschleife wird verlassen
                }
                else
                {
                    Console.WriteLine("Eingabe fehlerhaft");                //Ausgabe, dann wird SChleife wiederholt (wenn nötig, unendlich lang)
                    Console.WriteLine("Erneut veruchen");
                }


            }
            

            return typ;                                                    //Benötigter  Wert wird zurückgegeben
        }

        public static int breite_test()
        {
            Console.Write("Welche Schlüsselbreite möchten Sie haben?\nGeben Sie Ihren Wunsch vom als Zahl von 1 bis 20 ein!\nM:");

            int breite =0;

            for (int i = 0; i == 0;)
            {
                breite = Convert.ToInt32(Console.ReadLine());


                if (breite >=1&&breite<=20)//Wenn die Eingabe für unseren FAll zulässig ist
                {
                    Console.WriteLine("Eingbe erfolgreich");
                    break;                                                 //Endlosschleife wird verlassen
                }
                else
                {
                    Console.WriteLine("Eingabe fehlerhaft");                //Ausgabe, daraufhin wird Schleife wiederholt (wenn nötig, unendlich lang)
                    Console.WriteLine("Erneut veruchen");
                    
                }

                


            }
            return breite;


        }
        
        
        
        
        
        public static double schraubkopf(String form, int schluesselbreite)
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

            if (material == "V" || "v")
            {
                kilopreis = 7.12 
            }
            else if (material == "E" || "e")
            {
                kilopreis = 16,78
            }
            else
            {
                return -1
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
            
            
            double material;
            String[] gewinde;


            // Methode Schraubkopf

            Console.WriteLine("Welcher Schraubenype ist erwünscht?\nEs besteht die Auswahl zwischen Innensechskant und Außensechkant");

            String kopftyp=kopftest();      //Hier wird in einer Methode die Eingabe über den Typ der Schraube getätigt und auf zulässigkeit geprüft
            Console.WriteLine("Methode geht");
            int schluesselbreite = breite_test();

            



            //Methode Gewinde




            //Methode Preis
            
            double preis; 

            preis = Preis(); 

            if (preis == -1 )
            {
                Console.WriteLine("Fehler: Ungültige E
            }
            

            //Methode Festigkeit




            //Methode Masse





            //Ende





            Console.ReadKey();






                   









        }
    }
}

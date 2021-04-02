using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1
{
    class Program
    {
        static void Main(string[] args)     //Hauptprogramm
        {

            //Variablendeklariation für die Unterprogramme?

            

            //Methoden aufrufen




            /*int schluesselbreite;
            double material, masse;

            String[] gewinde;
            


            // Methode Schraubkopf

            Console.WriteLine("Welcher Schraubenype ist erwünscht?\nEs besteht die Auswahl zwischen Innensechskant und Außensechkant");

            String kopftyp=kopftest();      //Hier wird in einer Methode die Eingabe über den Typ der Schraube getätigt und auf zulässigkeit geprüft
            Console.WriteLine("Methode geht");
            int schluesselbreite = breite_test();

            



            //Methode Gewinde



            
            
            //Methode Festigkeit



                


            //Methode Masse

                masse = 1; 

            



             //Methode Preis

            double nettoeinzelpreis, nettokilopreis, netto50, netto100, einzelpreis, kilopreis, preis50, preis100, mws; 

            mws = 1.19;

                   // Preisvarianten berechnen 

            nettokilopreis = preis(); //gewicht, material, gewindeart, gewindelänge, schraubenkopf; KilopreisV kilopreisE
            nettoeinzelpreis = nettoeinzelpreis / masse; 
            netto50 = 50 * nettoeinzelpreis;
            netto100 = 100 * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws; 
            preis50 = netto50 * mws;
            preis100 = netto100 *mws;
        
                


                 // Ausgabe 

            
            Console. WriteLine("Preise:"); 
            Console.WriteLine ();
            Console.WriteLine("Nettopreise"); 
            Console.WriteLine("Stückpreis:          " + Math.Round(nettoeinzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(nettokilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(netto50, 2));
            Console.WriteLine ("preis 100 Stück:    " + Math.Round(netto100, 2));
            Console.WriteLine(); 
            Console.WriteLine("Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("Nettopreise"); 
            Console.WriteLine("Stückpreis:          " + Math.Round(einzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(kilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(preis50, 2));
            Console.WriteLine ("preis 100 Stück:    " + Math.Round(preis100, 2));
            
       */
       

            Console.ReadKey();


        }   //Hauptprogramm Ende

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



        public static void Kilopreis(double gewicht,string material, string gewindeart, string gewindelänge, string schraubenkopf,)

        {

        // Variablen festlegen
           double preis = 0;
           double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, einzelpreis, kilopreis, preis50, preis100, mws; 
            
         // Aufpreise festlegen
         
         const double aufpreis_Innensechskannt = 0.21;
         const double aufpreis_Teilgewinde = 0.16;
         const double aufpreis_Feingewinde = 0.27;
         const double kilopreis_verzinkt = 7.12;
         const double kilopreis_edelstahl = 16.78;

         //Grundpreis nach Material

            if (material == "V" || "v")
            {                                           // Verzinkete Schraube 
                kilopreis = kilopreis_verzinkt;
            }
         
            else
            {
                kilopreis = kilopreis_edelstahl;                     // Edelstahlschraube 
            }
          
        
        // Aufpreise 


            // Teilgewindelänge 

           if (gewindelänge == "D" ||"d")
            {
                preis = preis + aufpreis_Teilgewinde;
            }           
        
           // Innensechskannt
           if (schraubenkopf == "I" || "i")
            {
                preis = preis + aufpreis_Innensechskannt;
            }

           if (gewindeart == "F" || "f")
            {
                preis = preis + aufpreis_Feingewinde; 
            }


            mws = 1.19;

            // Preisvarianten berechnen 

            nettokilopreis = preis();
            nettoeinzelpreis = nettoeinzelpreis / masse;
            netto50 = 50 * nettoeinzelpreis;
            netto100 = 100 * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws;
            preis50 = netto50 * mws;
            preis100 = netto100 * mws;

            // Ausgabe der Preise 


            Console.WriteLine("Preise:");
            Console.WriteLine();
            Console.WriteLine("Nettopreise");
            Console.WriteLine("Stückpreis:          " + Math.Round(nettoeinzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(nettokilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(netto50, 2));
            Console.WriteLine("preis 100 Stück:    " + Math.Round(netto100, 2));
            Console.WriteLine();
            Console.WriteLine("Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("Nettopreise");
            Console.WriteLine("Stückpreis:          " + Math.Round(einzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(kilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(preis50, 2));
            Console.WriteLine("preis 100 Stück:    " + Math.Round(preis100, 2));
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


      
    }
}

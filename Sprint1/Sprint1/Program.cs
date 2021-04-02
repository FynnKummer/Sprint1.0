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
            Material();     //Abfrage welches Material die Schraube hat
            Schraubenkopf();    //Anfrage Welchen Schraubenkopf die Schraube hat
            Gewinde();      //Abfrage Gewinde(M8,M10,..), Schrauben- und Gewindelänge und Gewindeart
                            //Berechnung Schlüsselweite und Steigung
            Preis();    //Berechnung des Preises für die gewünschte Menge an Schrauben
            Festigkeit();   //Abfrage der Festigkeitsklasse des Materials + Berechnung der Festigkeit
            Geometrie();    //Berechnung der Schraube aus den eingegebenen Daten
            Ausgabe();  //Konsolenaugabe der Schraubeninformationen(Preis, Gewicht...)





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

        public static String Schraubenkopf()
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



        public static double Kilopreis(double gewicht,string material, string gewindeart, string gewindelänge, string schraubenkopf,)

        {

        // Variablen festlegen
           double preis = 0;
           double kilopreis; 
            
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

           return preis; 
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

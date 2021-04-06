using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sprint
{
    class Program
    {
        static void Main(string[] args)     //Hauptprogramm
        {

            //Variablendeklariation
            int Re = 0; //Variable für die Streckgrenze falls Matieral = unlegierter/legierter Stahl
            string sorte = "0"; //Variable für Stahlsorte falls Material = nichtrostende Stähle

            //Abfrage der Werte
            //Abfrage des Materials
            int material=abfrage_material();

            

            //Abfrage des Schraubenkopfes
            Console.WriteLine("Welchen Kopf hat die Schraube?");
            Console.WriteLine("'A' = Außenseckskant");
            Console.WriteLine("'I' = Innensechskant");
            string typ = Console.ReadLine();      //String einlesen

            //Abfrage des Gewindes (z.B. M8)
            Console.WriteLine("Welches Gewinde hat die Schraube?");
            Console.WriteLine("Mögliche Eingaben:");
            Console.WriteLine("M3 M4 M5 M6 M8 M10 M12 M16 M20");
            string gewinde = Console.ReadLine();      //String einlesen

            //Abfrage der Schraubenlänge
            Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
            int laenge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Gewindelänge
            Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
            int gewindelaenge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Gewindeart (FG/SG)
            Console.WriteLine("Welche Gewindeart hat die Schraube?");
            Console.WriteLine("'1' = Standardgewinde");
            Console.WriteLine("'2' = Feingewinde");
            int gewindeart = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Schraubenanzahl
            Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");           // in preis mit aufnehmen 
            int menge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Festigkeitsklasse 
           

            if (material == 1)  //für legierte/unlegierte Stähle
            {
                Console.WriteLine("Welche Zugfestigkeit hat die Schraube?");               // nur Standrandartwerte? (Festigkeit unf Streckgrenze in einem) 
                Console.WriteLine("Eingabewert * 100 N/mm²");
                int Rm = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

                Console.WriteLine("Welche Streckgrenze hat die Schraube?");
                Console.WriteLine(Rm + "Eingabewert * 10 N/mm²");
                Re = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen
            }
            else   //für nichtrostende Stähle
            {

                sorte = Console.ReadLine(); //String einlesen

                Console.WriteLine("Welche Zugfestigkeit hat die Schraube?");
                Console.WriteLine("Eingabewert * 10 N/mm²");
                int Rm = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen
            }

            //Methoden aufrufen


            //Schluesseweite(gewinde);   //Berechnung Schlüsselweite
            // Steigung(gewindeart);   //Berechnung Steigung
            // double preis=Preis(gewicht,material, menge, gewindeart,gewindelaenge, laenge, schraubenkopf);    //Berechnung des Preises für die gewünschte Menge an Schrauben
            // Festigkeit(Rm, Re, sorte);   //Berechnung der Festigkeit
            //  Geometrie();    //Berechnung der Schraube aus den eingegebenen Daten
            //  Ausgabe();  //Konsolenaugabe der Schraubeninformationen(Preis, Gewicht...)



            int schluesselbreite;
            double  masse;

           // String gewinde = "" ;
            


            // Methode Schraubkopf

            Console.WriteLine("Welcher Schraubenype ist erwünscht?\nEs besteht die Auswahl zwischen Innensechskant und Außensechkant");

            String kopftyp=kopftest();      //Hier wird in einer Methode die Eingabe über den Typ der Schraube getätigt und auf zulässigkeit geprüft
            Console.WriteLine("Methode geht");
           // schluesselbreite = breite_test();

            



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

            
            
       


            Console.ReadKey();


        }   //Hauptprogramm Ende

        public static String kopftest()
        {
            String typ = "";
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

            if (form == "I" || form == "i")       //Abfrage ob es sich um Außensechskant oder Innensechskant handelt
            {


            }
            else if (form == "A" || form == "a")
            {


            }
            else                            //Für den Fall einer Fehlerhaften eingabe 
            {
                Console.WriteLine("Fehlerhafte Eingabe. Starten Sie das Programm neu");
            }
            return 1;

        }

        
        public static double Geometrie()
        { 
        //Abfrage Gewinde(M8,M10,..), Schrauben- und Gewindelänge und Gewindeart
        //Berechnung Schlüsselweite und Steigung
        


            return 1;
        }



        public static void Preis(double gewicht, string material, string gewindeart, string gewindelänge, string schraubenkopf)

        {

            // Variablen festlegen
            double preis = 0;
            double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, einzelpreis, preis50, preis100, mws;

            // Aufpreise festlegen

            const double aufpreis_Innensechskannt = 0.21;
            const double aufpreis_Teilgewinde = 0.16;
            const double aufpreis_Feingewinde = 0.27;
            const double kilopreis_verzinkt = 7.12;
            const double kilopreis_edelstahl = 16.78;

            //Grundpreis nach Material

            if (material == "V" ||material== "v")
            {                                           // Verzinkete Schraube 
                kilopreis = kilopreis_verzinkt;
            }

            else
            {
                kilopreis = kilopreis_edelstahl;                     // Edelstahlschraube 
            }


            // Aufpreise 


            // Teilgewindelänge 

            if (gewindelänge == "D" ||gewindelänge== "d")
            {
                preis = preis + aufpreis_Teilgewinde;
            }

            // Innensechskannt
            if (schraubenkopf == "I" ||schraubenkopf== "i")
            {
                preis = preis + aufpreis_Innensechskannt;
            }

            if (gewindeart == "F" || gewindeart=="f")
            {
                preis = preis + aufpreis_Feingewinde;
            }


            mws = 1.19;

            // Preisvarianten berechnen 
            
            nettokilopreis = preis;              
            nettoeinzelpreis = nettokilopreis / masse();
            netto50 = 50 * nettoeinzelpreis;               
            netto100 = 100 * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws;
            preis50 = netto50 * mws;
            preis100 = netto100 * mws;

            // Ausgabe der Preise 


            Console.WriteLine("Preise:");
            Console.WriteLine();
            Console.WriteLine("Nettopreise                                  Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("Stückpreis:          " + Math.Round(nettoeinzelpreis, 2) + "      Stückpreis:          " + Math.Round(einzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(nettokilopreis, 2) + "        Kilopreis:           " + Math.Round(kilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(netto50, 2) + "               Preis 50 Stück:      " + Math.Round(preis50, 2));
            Console.WriteLine("preis 100 Stück:    " + Math.Round(netto100, 2) + "               preis 100 Stück:     " + Math.Round(preis100, 2));

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
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird gdfsajfnsaf

            return 1;
        }

        public static int abfrage_material()
        {
            
            Console.WriteLine("Welches Material hat die Schraube?");
            Console.WriteLine("'1' = Verzinkter Stahl");
            Console.WriteLine("'2' = V2A");
            Console.WriteLine("'3' = V4A");
            int material = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            return material;
        }

    }
}

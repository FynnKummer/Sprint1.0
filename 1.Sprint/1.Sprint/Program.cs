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
            //Abfrage der Werte
            //Abfrage des Materials
            int material = abfrage_material();

            //Abfrage des Schraubenkopfes
            String typ = abfrage_schraubenkopf();

           //Abfrage des Gewindes (z.B. M8)
            String gewinde = abfrage_gewinde();
            
            //Abfrage der Schraubenlänge
            Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
            int laenge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Gewindelänge
            Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
            int gewindelaenge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Gewindeart (FG/SG)
            int gewindeart = abfrage_gewindeart();
            
            //Abfrage der Schraubenanzahl
            Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");           // in preis mit aufnehmen 
            int menge = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            //Abfrage der Festigkeitsklasse 
            String Fk = abfrage_festigkeit(material);              


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

        
        public static void Geometrie(int d, double gewindelänge, double Schraubenlänge, string gewindetyp, string schraubenkopf)
        { 
            double h3, r, d1, d2, d3, s, flankenwikel;
            double p = 2;
            string schraubenkopf_a, gewindetyp_a  // Ausgeschriebene Strings 

        // Rechnungen 

         // Gewindetiefe   
            h3 = 0.6134 * p;

         // Rundung
            r = 0.1443 * p;

         //Flankendurchmesser 
            d2 = d - 0.64595 * p;

         //Kerndurchmesser 
            d3 = d - 1.2269;

         //Flankenwinkel 
            flankenwikel = 60;

         // Umwandlung der Strings 
           
            // Gewindetyp 
            if (Gewindetyp == "1")
            {
                gewindetyp_a = "(Standartgewinde)"
            }
            else
            {
                gewindetyp_a = "(Feingewinde)"
            }

            // Schreubenkopf
            if (schraubenkopf == "a" || schraubenkopf == "A")
            {
                schraubenkopf_a = "Außensechskant" 
            }
            else
            {
                schraubenkopf_a = "Innensechskant"
            }

         // Ausgabe

            Console.WriteLine("Geometie:");
            Console.WriteLine();
            Console.WriteLine("Schraubenlänge:       " + Schraubenlänge + "mm");
            Console.WriteLine("gewindelänge:         " + gewindelänge + "mm");
            Console.WriteLine("Gewindedurchmesser:   " + d + "mm");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Steigung:             " + p + " mm");
            Console.WriteLine("Gewindetiefe:         " + Math.Round(h3,2) + "mm");
            Console.WriteLine("Rundung:              " + r + " mm");
            Console.WriteLine("Flankendurchmesser:   " + Math.Round(d2,2) + "mm");
            Console.WriteLine("Kerndurchmesser:      " + Math.Round(d3,2) + "mm");
            Console.WriteLine("Flankenwinkel:        " + flankenwikel + "°");

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


        public static double festigkeit(string Fk)
        {
            
            //hier den Code reinschreiben
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird

            return 1;
        }

        public static double masse(int material, double schraubkopf, int laenge, int gewindelaenge, string Gewinde)
        {
            switch (Gewinde)
            {
                case "M3":

                    break;
                case "M4":

                    break;
                case "M5":

                    break;
                case "M6":

                    break;
                case "M8":

                    break;
                case "M10":

                    break;

                case "M12":

                    break;
                case "M16":

                    break;
                case "M20":

                    break;
            }
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

        public static String abfrage_schraubenkopf()
        {
            Console.WriteLine("Welchen Kopf hat die Schraube?");
            Console.WriteLine("'A' = Außenseckskant");
            Console.WriteLine("'I' = Innensechskant");
            string typ = Console.ReadLine();      //String einlesen

            return typ;
        }

        public static String abfrage_gewinde()
        {
            Console.WriteLine("Welches Gewinde hat die Schraube?");
            Console.WriteLine("Mögliche Eingaben:");
            Console.WriteLine("M3 M4 M5 M6 M8 M10 M12 M16 M20");
            string gewinde = Console.ReadLine();      //String einlesen

            return gewinde;

        }
   
        public static int abfrage_gewindeart()
        {
            Console.WriteLine("Welche Gewindeart hat die Schraube?");
            Console.WriteLine("'1' = Standardgewinde");
            Console.WriteLine("'2' = Feingewinde");
            int gewindeart = Convert.ToInt32(Console.ReadLine()); //Zahl einlesen

            return gewindeart;
        }
    
        public static String abfrage_festigkeit(int material)
        {
            string Fk = "0";
            if (material == 1)
            {
                Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?"); 
                Console.WriteLine("Mögliche Eingaben:");
                Console.WriteLine("5.8 6.8 8.8 9.8 10.9 12.9");
                Fk = Console.ReadLine(); //String einlesen 
            }
            else if (material == 2)
            {
                Console.WriteLine("'1' = A2-50");
                Console.WriteLine("'2' = A2-70");
                Fk = Console.ReadLine(); //String einlesen 
            }
            else
            {
                Fk = "3"; //"3" = A4-50
            }
            return Fk;
        }
    
    
    }
}

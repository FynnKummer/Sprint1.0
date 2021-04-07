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
            string material = abfrage_material();

            //Abfrage des Schraubenkopfes
            string typ = abfrage_schraubenkopf();

           //Abfrage des Gewindes (z.B. M8)
            string gewinde = abfrage_gewinde();
            
            //Abfrage der Schraubenlänge
            int laenge = abfrage_laenge();

            //Abfrage der Gewindelänge
            int gewindelaenge = abfrage_gewindelaenge(laenge);

            //Abfrage der Gewindeart (FG/SG)
            string gewindeart = abfrage_gewindeart();
            
            //Abfrage der Schraubenanzahl
            int menge = abfrage_menge();

            //Abfrage der Festigkeitsklasse 
            string Fk = abfrage_festigkeit(material);

            Console.WriteLine("hallo");
            //Volumen berechnen
            double vol = Volumen(typ, laenge, gewindelaenge, gewinde);


            //Masse berechnen
            double dichte, masse; //Einheit 

            dichte = dichte_abfrage(material);

            masse = masse_berechnen(dichte, vol);

            

            //Methoden aufrufen


            //Schluesseweite(gewinde);   //Berechnung Schlüsselweite
            // Steigung(gewindeart);   //Berechnung Steigung
            // double preis=Preis(gewicht,material, menge, gewindeart,gewindelaenge, laenge, schraubenkopf);    //Berechnung des Preises für die gewünschte Menge an Schrauben
            // Festigkeit(Rm, Re, sorte);   //Berechnung der Festigkeit
            // Geometrie();    //Berechnung der Schraube aus den eingegebenen Daten
            //Ausgabe(menge material, gewinde, laenge, gewindeart, gewindelaenge, typ, Fk);  //Konsolenaugabe der Schraubeninformationen(Preis, Gewicht...)


            //Ausgabe der Werte
            string a = ausgabe_material(material);
            string b = ausgabe_festigkeitsklasse(Fk);
            string c = ausgabe_schraubenkopf(typ);
            string d = ausgabe_gewindeart(gewindeart);
            Console.WriteLine("Gewählte Schraube: " + a + " " + b + " " + c + " " + d + " " + gewinde + "x" + laenge + "mm mit " + gewindelaenge + "mm Gewinde");
            Console.WriteLine("Technische Details:\n\t" );




            Console.ReadKey();
        }   //Hauptprogramm Ende
        
   

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
            string schraubenkopf_a, gewindetyp_a; // Ausgeschriebene Strings 

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
            if (gewindetyp == "1")
            {
                gewindetyp_a = "(Standartgewinde)";
            }
            else
            {
                gewindetyp_a = "(Feingewinde)";
            }

            // Schreubenkopf
            if (schraubenkopf == "a" || schraubenkopf == "A")
            {
                schraubenkopf_a = "Außensechskant";
            }
            else
            {
                schraubenkopf_a = "Innensechskant";
            }

         // Ausgabe

            Console.WriteLine("Geometie:");
            Console.WriteLine();
            Console.WriteLine("Schraubenlänge:       " + Schraubenlänge + "mm");
            Console.WriteLine("gewindelänge:         " + gewindelänge + "mm");
            Console.WriteLine("Gewindedurchmesser:   " + d + "mm");
            Console.WriteLine("Masse:                "   + "mm");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Steigung:             " + p + " mm");
            Console.WriteLine("Gewindetiefe:         " + Math.Round(h3,2) + "mm");
            Console.WriteLine("Rundung:              " + r + " mm");
            Console.WriteLine("Flankendurchmesser:   " + Math.Round(d2,2) + "mm");
            Console.WriteLine("Kerndurchmesser:      " + Math.Round(d3,2) + "mm");
            Console.WriteLine("Flankenwinkel:        " + flankenwikel + "°");

        }


        public static void Preis(double gewicht, string material, string gewindeart, string gewindelänge, string schraubenkopf, double masse)

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
            nettoeinzelpreis = nettokilopreis / masse;
            netto50 = 50 * nettoeinzelpreis;               
            netto100 = 100 * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws;
            preis50 = netto50 * mws;
            preis100 = netto100 * mws;

            // Ausgabe der Preise 

            preis_ausgabe(nettoeinzelpreis, nettokilopreis, netto50, netto100, preis50, preis100, einzelpreis, kilopreis);

            

        }

        public static void preis_ausgabe (double nettoeinzelpreis,double nettokilopreis, double netto50, double netto100,double preis50, double preis100, double einzelpreis, double kilopreis)
        {
            Console.WriteLine("Preise:");
            Console.WriteLine();
            Console.WriteLine("Nettopreise                                  Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("Stückpreis:          " + Math.Round(nettoeinzelpreis, 2) + "      Stückpreis:          " + Math.Round(einzelpreis, 2));
            Console.WriteLine("Kilopreis:           " + Math.Round(nettokilopreis, 2) + "        Kilopreis:           " + Math.Round(kilopreis, 2));
            Console.WriteLine("Preis 50 Stück:      " + Math.Round(netto50, 2) + "               Preis 50 Stück:      " + Math.Round(preis50, 2));
            Console.WriteLine("preis 100 Stück:    " + Math.Round(netto100, 2) + "               preis 100 Stück:     " + Math.Round(preis100, 2));
        }

        public static double dichte_abfrage(String material)
        {
            
            if (material == "1")
            {
                return 0.0079;
            }
            else if (material == "2")
            {
                return 0.0079;
            }
            else
            {
                return 0.008;
            }
        }

        public static double masse_berechnen(double volumen, double dichte)
        {
            double masse = volumen * dichte;

            return masse;
        }

        public static double festigkeit(string Fk)
        {
            
            //hier den Code reinschreiben
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird

            return 1;
        }

        public static double Volumen(String typ, int laenge, int gewindelaenge, string Gewinde, double vol)
        {

            double volumen_schraubenkopf;
            double volumen_schaft;


            switch (Gewinde)
            {
                //case "M3":
                //  if (typ == "A")
                //      break;

                case "M4":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 108.9508;
                        volumen_schaft = 3.55 * gewindelaenge+(laenge-gewindelaenge)*4;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 138.3500;
                        volumen_schaft = 3.55 * gewindelaenge + (laenge - gewindelaenge) * 4;
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                

                case "M5":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 178.8570;
                        volumen_schaft = 4.48 * gewindelaenge + (laenge - gewindelaenge) * 5;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 249.0851;
                        volumen_schaft = 4.48 * gewindelaenge + (laenge - gewindelaenge) * 5;
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;
                
                
                case "M6":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 317.2320;
                        volumen_schaft = 5.35 * gewindelaenge + (laenge - gewindelaenge) * 6;
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 406.2859;
                        volumen_schaft = 5.35 * gewindelaenge + (laenge - gewindelaenge) * 6;
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;
                case "M8":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 738.7050;
                        volumen_schaft = 7.19 * gewindelaenge + (laenge - gewindelaenge) * 8;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 937.1503;
                        volumen_schaft = 7.19 * gewindelaenge + (laenge - gewindelaenge) * 8;
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;
                case "M10":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 1624.1050;
                        volumen_schaft = 9.03 * gewindelaenge + (laenge - gewindelaenge) * 10;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 1733.4893;
                        volumen_schaft = 9.03 * gewindelaenge + (laenge - gewindelaenge) * 10;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }

                    break;

                case "M12":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 2313.3760;
                        volumen_schaft = 10.86 * gewindelaenge + (laenge - gewindelaenge) * 12;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 2534.0101;
                        volumen_schaft = 10.86 * gewindelaenge + (laenge - gewindelaenge) * 12;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }

                    break;
                case "M16":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 4647.7100;
                        volumen_schaft = 14.7 * gewindelaenge + (laenge - gewindelaenge) * 16;
                        vol = volumen_schraubenkopf + volumen_schaft;
                        

                    }
                    else
                    {
                        volumen_schraubenkopf = 5540.8195;
                        volumen_schaft = 14.7 * gewindelaenge + (laenge - gewindelaenge) * 16;
                        vol = volumen_schraubenkopf + volumen_schaft;
                        

                    }

                    break;
                case "M20":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 9492.9770;
                        volumen_schaft = 18.38 * gewindelaenge + (laenge - gewindelaenge) * 20;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 11634.3569;
                        volumen_schaft = 18.38 * gewindelaenge + (laenge - gewindelaenge) * 20;
                        vol = volumen_schraubenkopf + volumen_schaft;

                    }

                    break;
            }



            //hier den Code reinschreiben
            //Fehlermeldung sind normal und bleiben bis return xy; ergänzt wird gdfsajfnsaf

            return 1;
        }
    


        public static String abfrage_material()
        {           
            bool loop = false;
            string material = "";
            do
            { 
            Console.WriteLine("Welches Material hat die Schraube?");
            Console.WriteLine("'1' = Verzinkter Stahl");
            Console.WriteLine("'2' = V2A");
            Console.WriteLine("'3' = V4A");
            material = Console.ReadLine(); //Zahl einlesen
         
            if (material=="1" || material=="2" || material =="3")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);
            
            return material;
              
        }

        public static String abfrage_schraubenkopf()
        {
            bool loop = false;
            string typ = "";
            do
            { 
            Console.WriteLine("Welchen Kopf hat die Schraube?");
            Console.WriteLine("'A' = Außenseckskant");
            Console.WriteLine("'I' = Innensechskant");
            typ = Console.ReadLine();      //String einlesen

            if (typ=="A" || typ=="I")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);

            return typ;
        }

        public static String abfrage_gewinde()
        {
            bool loop = false;
            string gewinde = "";
            do
            { 
            Console.WriteLine("Welches Gewinde hat die Schraube?");
            Console.WriteLine("Mögliche Eingaben:");
            Console.WriteLine("M4 M5 M6 M8 M10 M12 M16 M20");
            gewinde = Console.ReadLine();      //String einlesen

            if (gewinde=="M3" || gewinde=="M4" || gewinde=="M5" || gewinde=="M6" || gewinde=="M8" || gewinde=="M10" || gewinde=="M12" || gewinde=="M20")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);

            return gewinde;

        }
   
        public static String abfrage_gewindeart()
        {
            bool loop = false;
            string gewindeart = "";
            do
            { 
            Console.WriteLine("Welche Gewindeart hat die Schraube?");
            Console.WriteLine("'1' = Standardgewinde");
            Console.WriteLine("'2' = Feingewinde");
            gewindeart = Console.ReadLine(); //Zahl einlesen

            if (gewindeart=="1" || gewindeart=="2")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);

            return gewindeart;
        }
    
        public static String abfrage_festigkeit(string material)
        {
            string Fk = "";
            bool loop = false;
            do
            { 
            switch (material)
            {
                case "1":
                    Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?"); 
                    Console.WriteLine("Mögliche Eingaben:");
                    Console.WriteLine("5.8 6.8 8.8 9.8 10.9 12.9");
                    Fk = Console.ReadLine(); //String einlesen 
                    break;

                case "2":  
                    Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?"); 
                    Console.WriteLine("Mögliche Eingaben:");
                    Console.WriteLine("'1' = A2-50");
                    Console.WriteLine("'2' = A2-70");
                    Fk = Console.ReadLine(); //String einlesen 
                    break;
            
                case "3":
                    Fk = "3"; //"3" = A4-50
                    break;
            }

            if (Fk=="1" || Fk=="2" || Fk=="3" || Fk=="5.8" || Fk=="6.8" || Fk=="8.8" || Fk=="9.8" || Fk=="10.9" || Fk=="12.9")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);
            
            return Fk;
        }
        
        public static int abfrage_laenge()
        { 
            string wert = "";
            int laenge = 0;

            bool loop = false;
            do
            { 
                Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit))
                {
                    laenge = Convert.ToInt32(wert); //Zahl einlesen
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return laenge;
        }

        public static int abfrage_gewindelaenge(int laenge)
        { 
            string wert = "";
            int gewindelaenge = 0;

            bool loop = false;
            do
            { 
                Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit))
                {
                    gewindelaenge = Convert.ToInt32(wert); //Zahl einlesen
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }

                if (gewindelaenge > laenge)
                {
                    Console.WriteLine("Das Gewinde kann nicht länger als die Schraube sein!");
                    loop = true;
                }
            } while (loop == true);

            return gewindelaenge;
        }

        public static int abfrage_menge()
        { 
            string wert = "";
            int menge = 0;

            bool loop = false;
            do
            { 
                Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit))
                {
                    menge = Convert.ToInt32(wert); //Zahl einlesen
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return menge;
        }

        public static String ausgabe_material(string material)
        {
            string a = "0";
            switch (material)
            {
                case "1": 
                    a = "Verzinkte Stahlschraube";
                    break;
                case "2":
                    a = "V2A Schraube";
                    break;
                case "3":
                    a = "V4A Schraube";
                    break;
            }

            return a;
        }

        public static String ausgabe_festigkeitsklasse(string Fk)
        {
            if (Fk == "1")
            {
                Fk = "A2-50";
            }
            else if (Fk == "2")
            {
                Fk = "A2-70";
            }
            else if (Fk == "3")
            {
                Fk = "A4-50";
            }

            return Fk;
        }

        public static String ausgabe_gewindeart(string gewindeart)
        {
            string b = "0";
            switch (gewindeart)
            {
                case "1":
                    b = "Standardgewinde";
                    break;
                case "2":
                    b = "Feingewinde";  
                    break;
            }

            return b;
        }

        public static String ausgabe_schraubenkopf(string typ)
        {
            string c = "0";
            switch (typ)
            {
                case "A":
                    c = "Außensechskant";
                    break;
                case "I":
                    c = "Innensechskant"; 
                    break;
            }

            return c;
        }
    }
}

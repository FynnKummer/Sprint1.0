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
            string material = abfrage_material();                                      //wenn Gewindelänge =Länge die Ausgabe auf "xx länge mit durchgehende Gewinde§ anpassen
                                                                                       // Preis fehlt noch in der Ausgabe
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

            //Berechnung der Werte
            //Volumen berechnen
            double vol = Volumen(typ, laenge, gewindelaenge, gewinde);


            //Masse berechnen
            double dichte, masse; //Einheit 
            dichte = dichte_abfrage(material);
            masse = masse_berechnen(dichte, vol);
            geometrie(gewinde, gewindelaenge, laenge,gewindeart,typ,vol,dichte);

            //Ausgabe der Eingabewerte
            string a = ausgabe_material(material);  
            string b = ausgabe_festigkeitsklasse(Fk);
            string c = ausgabe_schraubenkopf(typ);
            string d = ausgabe_gewindeart(gewindeart);
            Console.WriteLine("Gewählte Schraube: " + a + " " + b + " " + c + " " + d + " " + gewinde + "x" + laenge + "mm mit " + gewindelaenge + "mm Gewinde");
            Console.WriteLine("Technische Details:\n\t");

            //Preis(material, gewindeart, gewindelaenge, typ, masse, menge);
           
            Console.ReadKey();
        }   //Hauptprogramm Ende

        public static void geometrie(String gewinde, double gewindelänge, double Schraubenlänge, string gewindetyp, string schraubenkopf, double volumen, double dichte)
        { 
            double h3, r, d2, d3, flankenwikel;
            double p = 2;
            string schraubenkopf_a, gewindetyp_a; // Ausgeschriebene Strings
            String[] feld;

            feld= gewinde.Split('M');
            int d = Int32.Parse(feld[1]);

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
            //Gewicht
            double gewicht;
            gewicht = masse_berechnen(volumen, dichte);

            // Ausgabe

            Console.WriteLine("Geometie:");
            Console.WriteLine();
            Console.WriteLine("Schraubenlänge:       " + Schraubenlänge + "mm");
            Console.WriteLine("Gewindelänge:         " + gewindelänge + "mm");

            Console.WriteLine("Gewindedurchmesser:   " + d+ "mm");
            Console.WriteLine("Masse:                " +gewicht+ "g");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Steigung:             " + p + " mm");
            Console.WriteLine("Gewindetiefe:         " + Math.Round(h3,2) + "mm");
            Console.WriteLine("Rundung:              " + r + " mm");
            Console.WriteLine("Flankendurchmesser:   " + Math.Round(d2,2) + "mm");
            Console.WriteLine("Kerndurchmesser:      " + Math.Round(d3,2) + "mm");
            Console.WriteLine("Flankenwinkel:        " + flankenwikel + "°");
        }

        public static void Preis(string material, string gewindeart, string gewindelänge, string schraubenkopf, double masse, int menge)
        //double gewicht,
        {
            // Variablen festlegen
            double preis = 0;
            double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, Nettobestellpreis, einzelpreis, preis50, preis100, Bestellpreis;

            // Aufpreise festlegen
            const double aufpreis_Innensechskannt = 0.21;
            const double aufpreis_Teilgewinde = 0.16;
            const double aufpreis_Feingewinde = 0.27;
            const double kilopreis_verzinkt = 7.12;
            const double kilopreis_V2A = 16.78;
            const double kilopreis_V4A = 22.56;
            const double mws = 1.19;

            //Grundpreis nach Material
            if (material == "V" ||material== "v")
            {                                           // Verzinkete Schraube 
                kilopreis = kilopreis_verzinkt;
            }

            else if(true)//hier fehl die Bedingung
            {
                kilopreis = kilopreis_V2A;                     // Edelstahlschraube 
            }

            else
            {
                kilopreis = kilopreis_V4A;
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
   
            // Preisvarianten berechnen 
           
            nettokilopreis = preis;              
            nettoeinzelpreis = nettokilopreis / masse;
            netto50 = 50 * nettoeinzelpreis;               
            netto100 = 100 * nettoeinzelpreis;
            Nettobestellpreis = menge * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws;
            preis50 = netto50 * mws;
            preis100 = netto100 * mws;
            Bestellpreis = einzelpreis * menge;

            // Ausgabe der Preise 
            preis_ausgabe(nettoeinzelpreis, nettokilopreis, netto50, netto100, preis50, preis100, einzelpreis, kilopreis, Nettobestellpreis, Bestellpreis, menge);
        }

        public static void preis_ausgabe (double nettoeinzelpreis,double nettokilopreis, double netto50, double netto100,double preis50, double preis100, double einzelpreis, double kilopreis, double Nettobestellpreis, double Bestellpreis, int menge)
        {
            Console.WriteLine("Preise:");
            Console.WriteLine();
            Console.WriteLine("Nettopreise                                  Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("Summe ("+ menge+"Stück)   " + Math.Round(Nettobestellpreis,2) + "€" +  "         Summe (" );
            Console.WriteLine("Stückpreis:              " + Math.Round(nettoeinzelpreis, 2) +"€" +    "         Stückpreis:          " + Math.Round(einzelpreis, 2));
            Console.WriteLine("Kilopreis:               " + Math.Round(nettokilopreis, 2) +"€" +      "         Kilopreis:           " + Math.Round(kilopreis, 2));
            Console.WriteLine("Preis 50 Stück:          " + Math.Round(netto50, 2) + "€" +            "         Preis 50 Stück:      " + Math.Round(preis50, 2));
            Console.WriteLine("preis 100 Stück:         " + Math.Round(netto100, 2) + "€" +           "         Preis 100 Stück:     " + Math.Round(preis100, 2));
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

        public static void festigkeit(string Fk)
        {
            double Rm=0;
            double Re=0;

            switch (Fk)
            {
                case "5.8":
                    Rm = 500;
                    Re = 400;
                    break;
                case "6.8":
                    Rm = 600;
                    Re = 480;
                    break;
                case "8.8":
                    Rm = 800;
                    Re = 640;
                    break;
                case "9.8":
                    Rm = 900;
                    Re = 720;
                    break;
                case "10.9":
                    Rm = 1000;
                    Re = 900;
                    break;
                case "12.9":
                    Rm = 1200;
                    Re = 1080;
                    break;
                case "1":
                    Rm = 500;
                    Re = 210;
                    break;
                case "2":
                    Rm = 700;
                    Re = 450;
                    break;
                case "3":
                    Rm = 500;
                    Re = 210;
                    break;
            }
            Festigkeit_Ausgabe(Re, Rm);
        }

        public static void Festigkeit_Ausgabe(double Rm, double Re)
        {
            Console.WriteLine("Elastizitätsgrenze:" + Re + "N/mm^2");
            Console.WriteLine("Zugfestigkeit:" + Rm + "N/mm^2");
        }

        public static double Volumen(String typ, int laenge, int gewindelaenge, string Gewinde)
        {
            double vol=0;
            double volumen_schraubenkopf;
            double volumen_schaft;

            switch (Gewinde)
            {
                case "M4":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 108.9508;

                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 138.3500;

                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);

                        vol = volumen_schraubenkopf + volumen_schaft;
                        ;
                    }
                    break;
             
                case "M5":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 178.8570;

                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 249.0851;

                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48)* gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    break;
                               
                case "M6":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 317.2320;

                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35)* gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    else
                    {
                        volumen_schraubenkopf = 406.2859;

                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35)* gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }

                    break;

                case "M8":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 738.7050;

                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19)* gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 937.1503;

                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19)* gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;

                case "M10":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 1624.1050;

                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 1733.4893;

                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);

                        vol = volumen_schraubenkopf + volumen_schaft;

                    }
                    break;

                case "M12":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 2313.3760;

                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 2534.0101;
                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;

                case "M16":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 4647.7100;

                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 5540.8195;

                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;

                case "M20":
                    if (typ == "A" || typ == "a")
                    {
                        volumen_schraubenkopf = 9492.9770;

                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 11634.3569;

                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);

                        vol = volumen_schraubenkopf + volumen_schaft;
                    }

                    break;
            }

            return vol;
        }
        
        public static String abfrage_material()
        {           
            bool loop = false;  //Variable für die Schleife
            string material = "";   //Variable für die Abgfrage des Schraubenmaterials
    
            do //Schleife bis ein richtiger Wert eigegeben wird
            { 
                Console.WriteLine("Welches Material hat die Schraube?");
                Console.WriteLine("'1' = Verzinkter Stahl");
                Console.WriteLine("'2' = V2A");
                Console.WriteLine("'3' = V4A");
                material = Console.ReadLine(); //String einlesen
         
                if (material=="1" || material=="2" || material =="3")   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
            
            return material;            
        }

        public static String abfrage_schraubenkopf()
        {
            bool loop = false;  //Variable für die Schleife
            string typ = "";    //Variable für die Abgfrage des Schraubenkopfes

            do //Schleife bis ein richtiger Wert eigegeben wird
            { 
                Console.WriteLine("Welchen Kopf hat die Schraube?");
                Console.WriteLine("'A' = Außenseckskant");
                Console.WriteLine("'I' = Innensechskant");
                typ = Console.ReadLine();      //String einlesen

                if (typ=="A" || typ=="I")   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return typ;
        }

        public static String abfrage_gewinde()
        {
            bool loop = false;  //Variable für die Schleife
            string gewinde = "";    //Variable für die Abgfrage des Gewindes

            do //Schleife bis ein richtiger Wert eigegeben wird
            { 
                Console.WriteLine("Welches Gewinde hat die Schraube?");
                Console.WriteLine("Mögliche Eingaben:");
                Console.WriteLine("M4 M5 M6 M8 M10 M12 M16 M20");
                gewinde = Console.ReadLine();      //String einlesen

                if (gewinde=="M3" || gewinde=="M4" || gewinde=="M5" || gewinde=="M6" || gewinde=="M8" || gewinde=="M10" || gewinde=="M12" || gewinde=="M20")    //Richtige Eingabe
                {
                    loop = false;
                }
                else //falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return gewinde;
        }
   
        public static String abfrage_gewindeart()
        {
            bool loop = false;  //Variable für die Schleife
            string gewindeart = ""; //Variable für die Abgfrage der Gewindeart

            do //Schleife bis ein richtiger Wert eigegeben wird
            { 
                Console.WriteLine("Welche Gewindeart hat die Schraube?");
                Console.WriteLine("'1' = Standardgewinde");
                Console.WriteLine("'2' = Feingewinde");
                gewindeart = Console.ReadLine(); //String einlesen

                if (gewindeart=="1" || gewindeart=="2") //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return gewindeart;
        }
    
        public static String abfrage_festigkeit(string material)
        {
            string Fk = ""; //Variable für die Abgfrage der Festigkeitsklasse
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert eigegeben wird
            { 
                switch (material) //Abfrage der Festigkeitsklasse abhängig vom Material
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

            if (Fk=="1" || Fk=="2" || Fk=="3" || Fk=="5.8" || Fk=="6.8" || Fk=="8.8" || Fk=="9.8" || Fk=="10.9" || Fk=="12.9")  //Richtige Eingabe
            {
                loop = false;
            }
            else //Falsche Eingabe
            {
                Console.WriteLine("Falsche Eingabe");
                loop = true;
            }
            } while (loop == true);
            
            return Fk;
        }
        
        public static int abfrage_laenge()
        { 
            string wert = "";   //Variable für den Eingabewert
            int laenge = 0; //Variable für die Abgfrage der Schraubenlänge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            { 
                Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    laenge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahlt
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return laenge;
        }

        public static int abfrage_gewindelaenge(int laenge)
        { 
            string wert = "";   //Variable für den Eingabewert
            int gewindelaenge = 0;  //Variable für die Abgfrage der Gewindelänge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            { 
                Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    gewindelaenge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahlt
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }

                if (gewindelaenge > laenge) //Falscher Wert
                {
                    Console.WriteLine("Das Gewinde kann nicht länger als die Schraube sein!");
                    loop = true;
                }
            } while (loop == true);

            return gewindelaenge;
        }

        public static int abfrage_menge()
        { 
            string wert = "";   //Variable für den Eingabewert
            int menge = 0;  //Variable für die Abfrage der Menge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            { 
                Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");
                wert = Console.ReadLine(); //String einlesen
                
                if(wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    menge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahlt
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            return menge;
        }

        public static String ausgabe_material(string material)  //Der Variable dem richtigen Ausgabestring zuweisen
        {
            switch (material)
            {
                case "1": 
                    material = "Verzinkte Stahlschraube";
                    break;
                case "2":
                    material = "V2A Schraube";
                    break;
                case "3":
                    material = "V4A Schraube";
                    break;
            }

            return material;
        }

        public static String ausgabe_festigkeitsklasse(string Fk) //Der Variable dem richtigen Ausgabestring zuweisen
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

        public static String ausgabe_gewindeart(string gewindeart) //Der Variable dem richtigen Ausgabestring zuweisen
        {
            switch (gewindeart)
            {
                case "1":
                    gewindeart = "Standardgewinde";
                    break;
                case "2":
                    gewindeart = "Feingewinde";  
                    break;
            }

            return gewindeart;
        }

        public static String ausgabe_schraubenkopf(string typ) //Der Variable dem richtigen Ausgabestring zuweisen
        {
            switch (typ)
            {
                case "A":
                    typ = "Außensechskant";
                    break;
                case "I":
                    typ = "Innensechskant"; 
                    break;
            }

            return typ;
        }
    }
}

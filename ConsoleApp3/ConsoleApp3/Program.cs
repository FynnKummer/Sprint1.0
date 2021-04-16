using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)     //Hauptprogramm
        {

            Schraube a = new Schraube(); //erstellen eines Objektes des Typs Schraube
            //Abfrage der Werte
            //Abfrage des Materials
            a.mat();                                      //wenn Gewindelänge =Länge die Ausgabe auf "xx länge mit durchgehende Gewinde§ anpassen
                                                                                                // Preis fehlt noch in der Ausgabe
                                                                                                //Abfrage des Schraubenkopfes                                              // Statt == in den if Anweisungen equals Methode....Groß und Kleinschreibung ist dann egal
            a.type();                              // 

            //Abfrage des Gewindes (z.B. M8)
            String[] feld = { "M4", "M5", "M6", "M8", "M10", "M12", "M16", "M20" };
            a.gew(feld);

            //Abfrage der Schraubenlänge
            a.len();

            //Abfrage der Gewindelängen
            a.gewlen();

            //Abfrage der Gewindeart (FG/SG)
            a.gewart();

            //Abfrage der Schraubenanzahl
            a.amount();

            //Abfrage der Festigkeitsklasse 
            a.fest();

            

            Console.Clear();    //Konsole bereinigen

            //Berechnung der Werte
            //Volumen berechnen
            
            

            //Ausgabe der Eingabewerte
            string e = Methoden.ausgabe_material(a.material);             
            string b = Methoden.ausgabe_festigkeitsklasse(a.festigkeit);
            string c = a.ausgabe_schraubenkopf();
            string d = a.ausgabe_gewindeart();
            Console.WriteLine("\nGewählte Schraube: " + e + " " + b + " " + c + " " + d + " " + a.gewinde + "x" + a.laenge + "mm mit " + a.gewindelaenge + "mm Gewinde\n");

            //Masse berechnen
            a.masse = a.dichte * a.volumen;
            
            
            a.geometrie();

            //Preis berechnen und ausgeben
            a.Preis();

            Console.ReadKey();
        }   //Hauptprogramm Ende


    }
    class Methoden
    {

        

        

       
       
        public static void preis_ausgabe(double nettoeinzelpreis, double nettokilopreis, double netto50, double netto100, double preis50, double preis100, double einzelpreis, double kilopreis, double Nettobestellpreis, double Bestellpreis, int menge)
        {
            string summenenstring = "Summe (" + menge + "Stück):";

            Console.WriteLine("Preise:");
            Console.WriteLine();
            Console.WriteLine("Nettopreise                                  Preise inkl. Mehrwertsteuer");
            Console.WriteLine();
            Console.WriteLine("  {0,-18} {1,8:c} EUR {2} {0,-18} {3,8:c} EUR", summenenstring, Math.Round(Nettobestellpreis, 2), "            ", Math.Round(Bestellpreis));
            Console.WriteLine("  {0,-18} {1,8:c} EUR {2} {0,-18} {3,8:c} EUR", "Stückpreis:", Math.Round(nettoeinzelpreis, 2), "            ", Math.Round(einzelpreis, 2));
            Console.WriteLine("  {0,-18} {1,8:c} EUR {2} {0,-18} {3,8:c} EUR ", "Kilopreis:", Math.Round(nettokilopreis, 2), "            ", Math.Round(kilopreis, 2));
            Console.WriteLine("  {0,-18} {1,8:c} EUR {2} {0,-18} {3,8:c} EUR", "Preis 50 Stück:", Math.Round(netto50, 2), "            ", Math.Round(preis50, 2));
            Console.WriteLine("  {0,-18} {1,8:c} EUR {2} {0,-18} {3,8:c} EUR ", "Preis 100 Stück:", Math.Round(netto100, 2), "            ", Math.Round(preis100, 2));

        }

        
        



        public static void festigkeit(string Fk)
        {
            double Rm = 0;
            double Re = 0;

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
        } //muss eventuel wieder in Methoden zurück

        public static void Festigkeit_Ausgabe(double Rm, double Re)
        {
            Console.WriteLine("Elastizitätsgrenze:" + Re + "N/mm^2");
            Console.WriteLine("Zugfestigkeit:" + Rm + "N/mm^2");
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
            if (Fk.Equals("1"))
            {
                Fk = "A2-50";
            }
            else if (Fk.Equals("2"))
            {
                Fk = "A2-70";
            }
            else if (Fk.Equals("3"))
            {
                Fk = "A4-50";
            }

            return Fk;
        }

       

       







    }

    class Schraube
    {
        
        public int menge;

        public int laenge;
        public double volumen;
        public String schluesselbreite;
        public String typ;
        public String festigkeit;

        public String gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public String gewinde;

        public String material;
        public double dichte;
        public double masse;

        public double gesamtgewicht;


        public void len()
        {
            string wert = "";   //Variable für den Eingabewert
            int laenge = 0; //Variable für die Abgfrage der Schraubenlänge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
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

            this.laenge=laenge;
        }

        public void mat()
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

                if (material.Equals("1") || material.Equals("2") || material.Equals("3"))   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
            this.material= material;
        }

        public void type()
        {
            bool loop = false;  //Variable für die Schleife
            string typ = "";    //Variable für die Abgfrage des Schraubenkopfes

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welchen Kopf hat die Schraube?");
                Console.WriteLine("'A' = Außenseckskant");
                Console.WriteLine("'I' = Innensechskant");
                typ = Console.ReadLine();      //String einlesen

                if (typ.Equals("A") || typ.Equals("I"))   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
            this.typ = typ;
        }

        public void gew(String[] feld)
        {
            bool loop = false;  //Variable für die Schleife
            string gewinde = "";    //Variable für die Abgfrage des Gewindes

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welches Gewinde hat die Schraube?");
                Console.WriteLine("Mögliche Eingaben:");
                Console.WriteLine("M4 M5 M6 M8 M10 M12 M16 M20");
                gewinde = Console.ReadLine();      //String einlesen

                if (feld_legit(feld,gewinde))    //Richtige Eingabe
                {
                    loop = false;
                }
                else //falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            this.gewinde =gewinde;
        }

        public void gewart()
        {
            bool loop = false;  //Variable für die Schleife
            string gewindeart = ""; //Variable für die Abgfrage der Gewindeart

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welche Gewindeart hat die Schraube?");
                Console.WriteLine("'1' = Standardgewinde");
                Console.WriteLine("'2' = Feingewinde");
                gewindeart = Console.ReadLine(); //String einlesen

                if (gewindeart.Equals("1") || gewindeart.Equals("2")) //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            this.gewindeart= gewindeart;
        }

        public void amount()
        {
            string wert = "";   //Variable für den Eingabewert
            int menge = 0;  //Variable für die Abfrage der Menge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
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

            this.menge=menge;
        }

        public void gewlen()
        {
            string wert = "";   //Variable für den Eingabewert
            int gewindelaenge = 0;  //Variable für die Abgfrage der Gewindelänge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    gewindelaenge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahlt
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }

                if (gewindelaenge > this.laenge) //Falscher Wert
                {
                    Console.WriteLine("Das Gewinde kann nicht länger als die Schraube sein!");
                    loop = true;
                }
            } while (loop == true);

            this.gewindelaenge= gewindelaenge;
        }

        public void density()
        {
            if (this.material.Equals("1"))
            {
                this.dichte= 0.0079;
            }
            else if (this.material.Equals("2"))
            {
                this.dichte= 0.0079;
            }
            else
            {
                this.dichte= 0.008;
            }
        }

        public void fest()
        {
            string Fk = ""; //Variable für die Abgfrage der Festigkeitsklasse
            bool loop = false;  //Variable für die Schleife
            String[] festigkeitsklassen = { "1", "2", "3", "5.8", "6.8", "8.8", "9.8", "10.9", "12.9" };

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                switch (this.material) //Abfrage der Festigkeitsklasse abhängig vom Material
                {
                    case "1":
                        Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?");
                        Console.WriteLine("Mögliche Eingaben:");
                        Console.WriteLine("5.8 6.8 8.8 9.8 10.9 12.9");
                        this.festigkeit = Console.ReadLine(); //String einlesen 
                        break;

                    case "2":
                        Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?");
                        Console.WriteLine("Mögliche Eingaben:");
                        Console.WriteLine("'1' = A2-50");
                        Console.WriteLine("'2' = A2-70");
                        this.festigkeit = Console.ReadLine(); //String einlesen 
                        break;

                    case "3":
                        this.festigkeit = "3"; //"3" = A4-50
                        break;
                }

                if (feld_legit(festigkeitsklassen,this.festigkeit))  //Richtige Eingaben
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            this.festigkeit=Fk;
        }

        public Boolean feld_legit(String[] feld, string a)
        {
            for (int i = 0; i < feld.Length; i++)
            {
                if (a.Equals(feld[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void vol()
        {
            double vol = 0;
            double volumen_schraubenkopf;
            double volumen_schaft;

            switch (this.gewinde)
            {
                case "M4":
                    if (this.gewinde.Equals("A"))
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
                    }
                    break;

                case "M5":
                    if (this.gewinde.Equals("A"))
                    {
                        volumen_schraubenkopf = 178.8570;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 249.0851;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M6":
                    if (this.gewinde.Equals("A"))
                    {
                        volumen_schraubenkopf = 317.2320;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 406.2859;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M8":
                    if (this.gewinde.Equals("A"))
                    {
                        volumen_schraubenkopf = 738.7050;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    else
                    {
                        volumen_schraubenkopf = 937.1503;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        vol = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M10":
                    if (this.gewinde.Equals("A"))
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
                    if (this.gewinde.Equals("A"))
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
                    if (this.gewinde.Equals("A"))
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
                    if (this.gewinde.Equals("A"))
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
            this.volumen= vol;
        }

        public void geometrie()
        {
            double h3, r, d2, d3, flankenwikel;
            double p = 0;
            string schraubenkopf_a, gewindetyp_a; // Ausgeschriebene Strings

            String[] feld = gewinde.Split('M');
            int d = Int32.Parse(feld[1]);

            //Gewindesteigung
            if (this.gewindeart.Equals("1"))
            {
                switch (this.gewinde)
                {
                    case "M4":
                        p = 0.7;
                        break;

                    case "M5":
                        p = 0.8;
                        break;

                    case "M6":
                        p = 1;
                        break;

                    case "M8":
                        p = 1.25;
                        break;

                    case "M10":
                        p = 1.5;
                        break;

                    case "M12":
                        p = 1.75;
                        break;

                    case "M16":
                        p = 2;
                        break;

                    case "M20":
                        p = 2.5;
                        break;
                }
            }

            if (this.gewindeart.Equals("2"))//Die if schleife wird zu spät beendet
            {
                switch (gewinde)
                {
                    case "M4":
                        p = 0.5;
                        break;

                    case "M5":
                        p = 0.5;
                        break;

                    case "M6":
                        p = 0.75;
                        break;

                    case "M8":
                        p = 0.75;

                        break;

                    case "M10":
                        p = 1;
                        break;

                    case "M12":
                        p = 1.25;
                        break;

                    case "M16":
                        p = 1.5;
                        break;

                    case "M20":
                        p = 1.5;
                        break;
                }
            }

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
            if (this.gewindeart == "1")
            {
                gewindetyp_a = "(Standardgewinde)";
            }
            else
            {
                gewindetyp_a = "(Feingewinde)";
            }

            // Schrubenkopf
            if (this.typ== "a" || this.typ == "A")
            {
                schraubenkopf_a = "Außensechskant";
            }
            else
            {
                schraubenkopf_a = "Innensechskant";
            }

        //Gewicht

            this.masse = this.volumen * this.dichte;
            
            
            this.gesamtgewicht = this.masse*this.menge;

            // Ausgabe
            Console.WriteLine("Technische Details:\n");
            Console.WriteLine("Schraubenlänge:       " + this.laenge + "mm");
            Console.WriteLine("Gewindelänge:         " + this.gewindelaenge + "mm");
            Console.WriteLine("Gewindedurchmesser:   " + d + "mm");
            Console.WriteLine("Masse pro Stück:      " + Math.Round(this.masse, 2) + "g");
            Console.WriteLine("Gesamtgewicht:        " + Math.Round(this.gesamtgewicht, 2) + "g");
            Console.WriteLine("Steigung:             " + p + " mm");
            Console.WriteLine("Gewindetiefe:         " + Math.Round(h3, 2) + "mm");
            Console.WriteLine("Rundung:              " + r + " mm");
            Console.WriteLine("Flankendurchmesser:   " + Math.Round(d2, 2) + "mm");
            Console.WriteLine("Kerndurchmesser:      " + Math.Round(d3, 2) + "mm");
            Console.WriteLine("Flankenwinkel:        " + flankenwikel + "°\n");
        }

        public void Preis()
        {
            // Variablen festlegen
            double preis = 0;
            double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, Nettobestellpreis, einzelpreis, preis50, preis100, Bestellpreis, massekilo;

            // Aufpreise festlegen
            const double aufpreis_Innensechskannt = 0.21;
            const double aufpreis_Teilgewinde = 0.16;
            const double aufpreis_Feingewinde = 0.27;
            const double kilopreis_verzinkt = 12.12;
            const double kilopreis_V2A = 26.78;
            const double kilopreis_V4A = 35.56;
            const double mws = 1.19;

            //Grundpreis nach Material
            if (this.material.Equals("1"))
            {                                           // Verzinkete Schraube 
                preis = kilopreis_verzinkt;
            }
            else if (this.material.Equals("2")) //hier fehl die Bedingung
            {
                preis = kilopreis_V2A;                     // Edelstahlschraube 
            }
            else
            {
                preis = kilopreis_V4A;
            }

            // Aufpreise 
            // Teilgewindelänge 
            if (this.gewindelaenge != laenge)
            {
                preis = preis + aufpreis_Teilgewinde;
            }

            // Innensechskannt
            if (this.typ.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            {
                preis = preis + aufpreis_Innensechskannt;
            }

            // Feingewinde 
            if (this.gewindeart.Equals("F", StringComparison.InvariantCultureIgnoreCase))
            {
                preis = preis + aufpreis_Feingewinde;
            }

            // Preisvarianten berechnen            
            massekilo = 0.001 * masse;

            nettokilopreis = preis;
            nettoeinzelpreis = nettokilopreis * massekilo;
            netto50 = 50 * nettoeinzelpreis;
            netto100 = 100 * nettoeinzelpreis;
            Nettobestellpreis = menge * nettoeinzelpreis;

            einzelpreis = nettoeinzelpreis * mws;
            kilopreis = nettokilopreis * mws;
            preis50 = netto50 * mws;
            preis100 = netto100 * mws;
            Bestellpreis = einzelpreis * menge;

            // Ausgabe der Preise 
            Methoden.preis_ausgabe(nettoeinzelpreis, nettokilopreis, netto50, netto100, preis50, preis100, einzelpreis, kilopreis, Nettobestellpreis, Bestellpreis, this.menge);
        }

        public String ausgabe_schraubenkopf() //Der Variable dem richtigen Ausgabestring zuweisen
        {
            switch (this.typ)
            {
                case "A":
                    this.typ = "Außensechskant";
                    break;
                case "I":
                    this.typ = "Innensechskant";
                    break;
            }

            return typ;
        }

        public String ausgabe_gewindeart() //Der Variable dem richtigen Ausgabestring zuweisen
        {
            switch (this.gewindeart)
            {
                case "1":
                    this.gewindeart = "Standardgewinde";
                    break;
                case "2":
                    this.gewindeart = "Feingewinde";
                    break;
            }
            return this.gewindeart;
        }




    }



}


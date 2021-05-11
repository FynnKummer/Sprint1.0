using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubengott
{
    class Schraube
    {
        public string name; // Vom Benutzer festgeleter Name für die Schraube
        public int menge;
        public int laenge;
        public double volumen;
        public int schluesselbreite;
        public string typ; //Innensechskant/Ausßensechskant
        public string festigkeit;
        

        public string gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public string gewinde;
        public double gewindetiefe;  //  belegt 
        public double gewinderundung; //  belegt 

        public double flankendurchmesser; //  belegt 
        public double kerndurchmesser; //  belegt 
        public double flankenwinkel;  //belegt

        public double elastizitätsgrenze; // belegt
        public double Zugfestigkeit; //belegt


        public string material;
        public double dichte;
        public double masse;
        public double gesamtgewicht;

        public double preis_summe;  //
        public double stückpreis; //
        public double nettopreis_Summe;  // belegt
        public double nettoeinzelpreis;  //belegt

        public string bemerkung;


        #region "Methoden für Berechnungen""

        //Berechnungen 
        public void berechnen()
        {
            dichte_festlegen();
            vol_berechnen();
            gewsteigung_schlbreite_festlegen();
            geometrie();
            gewicht_berechnen();
            festigkeit_berechnen();
            preis_berechnen();


        }
        public void dichte_festlegen()
        {
            if (this.material.Equals("Verzinkter Stahl"))
            {
                this.dichte = 0.0079; //Verzinkt
            }
            else if (this.material.Equals("V2A"))
            {
                this.dichte = 0.0079; //V2A
            }
            else
            {
                this.dichte = 0.008; //V4A
            }
        }
        public void vol_berechnen()
        {
            double volumen_schraubenkopf;
            double volumen_schaft;

            switch (this.gewinde)
            {
                case "M4":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 108.9508;
                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 138.3500;
                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M5":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 178.8570;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 249.0851;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M6":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 317.2320;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 406.2859;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M8":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 738.7050;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 937.1503;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M10":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 1624.1050;
                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 1733.4893;
                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M12":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 2313.3760;
                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 2534.0101;
                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M16":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 4647.7100;
                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 5540.8195;
                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M20":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 9492.9770;
                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 11634.3569;
                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;
            }
        }

        public void preis_berechnen()//eventuell für jede Preisvariable eine eigene Methode
        {
            // Variablen festlegen
            double preis;
            double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, Nettobestellpreis, einzelpreis, preis50, preis100, Bestellpreis, massekilo;

            // Aufpreise festlegen
            const double aufpreis_Innensechskant = 0.21;
            const double aufpreis_Teilgewinde = 0.16;
            const double aufpreis_Feingewinde = 0.27;
            const double kilopreis_verzinkt = 12.12;
            const double kilopreis_V2A = 26.78;
            const double kilopreis_V4A = 35.56;
            const double mws = 1.19;

            //Grundpreis nach Material
            if (this.material.Equals("Verzinkter Stahl"))
            {                                           // Verzinkte Schraube 
                preis = kilopreis_verzinkt;
            }
            else if (this.material.Equals("V2A")) 
            {
                preis = kilopreis_V2A;                     // Edelstahlschraube 
            }
            else
            {
                preis = kilopreis_V4A;
            }

            // Aufpreise 
            // Teilgewindelänge 
            if (this.gewindelaenge != this.laenge)
            {
                preis = preis + aufpreis_Teilgewinde;
            }

            // Innensechskant
            if (this.typ.Equals("Innensechskant", StringComparison.InvariantCultureIgnoreCase))
            {
                preis = preis + aufpreis_Innensechskant;
            }

            // Feingewinde 
            if (this.gewindeart.Equals("Außensechskant", StringComparison.InvariantCultureIgnoreCase))
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

            // Objekt 

            preis_summe = Bestellpreis;
            stückpreis = einzelpreis;
            this.nettopreis_Summe = Nettobestellpreis;
            this.nettoeinzelpreis = nettoeinzelpreis;
        }

        public void gewsteigung_schlbreite_festlegen()
        {
            String[] feld = this.gewinde.Split('M');
            int d = Int32.Parse(feld[1]);

            //Gewindesteigung + Schlüsselbreite
            if (gewindeart.Equals("Standardgewinde"))
            {
                switch (this.gewinde)
                {
                    case "M4":
                        this.gewindesteigung = 0.7;
                        this.schluesselbreite = 7;
                        break;

                    case "M5":
                        this.gewindesteigung = 0.8;
                        this.schluesselbreite = 8;
                        break;

                    case "M6":
                        this.gewindesteigung = 1;
                        this.schluesselbreite = 10;
                        break;

                    case "M8":
                        this.gewindesteigung = 1.25;
                        this.schluesselbreite = 13;
                        break;

                    case "M10":
                        this.gewindesteigung = 1.5;
                        this.schluesselbreite = 17;
                        break;

                    case "M12":
                        this.gewindesteigung = 1.75;
                        this.schluesselbreite = 19;
                        break;

                    case "M16":
                        this.gewindesteigung = 2;
                        this.schluesselbreite = 24;
                        break;

                    case "M20":
                        this.gewindesteigung = 2.5;
                        this.schluesselbreite = 30;
                        break;
                }
            }
            if (this.gewindeart.Equals("Fenigewinde"))//Die if Schleife wird zu spät beendet
            {
                switch (this.gewinde)
                {
                    case "M4":
                        this.gewindesteigung = 0.5;
                        break;

                    case "M5":
                        this.gewindesteigung = 0.5;
                        break;

                    case "M6":
                        this.gewindesteigung = 0.75;
                        break;

                    case "M8":
                        this.gewindesteigung = 0.75;

                        break;

                    case "M10":
                        this.gewindesteigung = 1;
                        break;

                    case "M12":
                        this.gewindesteigung = 1.25;
                        break;

                    case "M16":
                        this.gewindesteigung = 1.5;
                        break;

                    case "M20":
                        this.gewindesteigung = 1.5;
                        break;
                }
            }
        }

        public void geometrie()
        {
            double h3, r, d2, d3, flankenwikel;
            String[] feld = this.gewinde.Split('M');
            int d = Int32.Parse(feld[1]);
            // Rechnungen   
            h3 = 0.6134 * this.gewindesteigung;    // Gewindetiefe 
            r = 0.1443 * this.gewindesteigung; // Rundung
            d2 = d - 0.64595 * this.gewindesteigung;   //Flankendurchmesser 
            d3 = d - 1.2269;    //Kerndurchmesser 
            flankenwikel = 60;  //Flankenwinkel 

            // Speichern in Schraube 

            this.gewindetiefe = h3;
            this.gewinderundung = r;
            this.flankendurchmesser = d2;
            this.kerndurchmesser = d3;
            this.flankenwinkel = flankenwikel;
        }

        public void gewicht_berechnen()
        {

            this.masse = this.volumen * this.dichte;
            this.gesamtgewicht = this.masse * this.menge;
        }

        public void festigkeit_berechnen()
        {
            double Rm = 0;
            double Re = 0;

            switch (this.festigkeit)
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
                case "V2A 50":     //v4a 50er Festigkeitsklasse
                    Rm = 500;
                    Re = 210;
                    break;
                case "V2A 70":    //v2a 70er Festigkeitsklasse
                    Rm = 700;
                    Re = 450;
                    break;
                case "V4A 70":     //v4a 50er Festigkeitsklasse
                    Rm = 500;
                    Re = 210;
                    break;
            }
            this.elastizitätsgrenze = Re;
            this.Zugfestigkeit = Rm;
        }

        #endregion

    }
}
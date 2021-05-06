using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubengott
{
    class Schraube
    {
        public String name; // Vom Benutzer festgeleter Name für die Schraube
        public int menge;
        public int laenge;
        public double volumen;
        public int schluesselbreite;
        public String typ;      //Innensechskant/Ausßensechskant
        public String festigkeit;
        public String festaus;//Festigkeitsklasse ausgeschrieben

        public String gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public String gewinde;
        public double gewindetiefe;  //  belegt 
        public double gewinderundung; //  belegt 
        public double flankendurchmesser; //  belegt 
        public double kerndurchmesser; //  belegt 
        public double flankenwinkel;  //belegt

        public double elastizitätsgrenze; // belegt
        public double Zugfestigkeit; //belegt


        public String material;
        public String mataus;//Material ausgeschrieben
        public double dichte;
        public double masse;
        public double gesamtgewicht;

        public double preis_summe;  //
        public double stückpreis; //
        public double nettopreis_Summe;  // belegt
        public double nettoeinzelpreis;  //belegt

        //Auswahlen der Comboboxen den Variablen zuweisen
        public void gewinde_festlegen(String gew)
        {
            this.gewinde = gew;
        }
        public void kopf_festlegen(String kopf)
        {
            this.typ = kopf;

        }
        public void festigkeit_festlegen(String fest)
        {
            this.festigkeit = fest;
        }

        //Eingaben der Textboxen den Variablen zuweisen
        public void laenge_festlegen(int laenge)
        {

        }
        public void gewlen_festlegen(int gewlen)
        {

        }


        //Berechnungen 
        public void masse_berechnen()
        {

        }
        public void vol_berechnen()
        {

        }
        public void preis_berechnen()//eventuell für jede Preisvariable eine eigene Methode
        {

        }


    }
}

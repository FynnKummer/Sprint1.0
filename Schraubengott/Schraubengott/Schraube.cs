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
    }
}

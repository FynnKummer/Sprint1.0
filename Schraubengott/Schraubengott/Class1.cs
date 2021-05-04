using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubengott
{
    class Class1
    {
        public static void Main()
        {
            Schraube[] feld = new Schraube[5];

            for( int i = 0; i < feld.Length; i++)
            {
                feld[i] = new Schraube();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchip
{
    public class Schip
    {
        public int MaximumGewicht { get; set; } = 100;

        private ContainerStapel containerStapel = new ContainerStapel();

        private int MiddelSortY;
        private bool yEmpty = true;
        private int TotaalGewichtSchip;
        private int GewichtOver;

        public int MaxGewichtSchip(int Gewicht)
        {
            TotaalGewichtSchip = Gewicht + TotaalGewichtSchip;
            GewichtOver = MaximumGewicht - TotaalGewichtSchip;
            return GewichtOver;
        }

        public bool MinGewichtSchip()
        {
            if (TotaalGewichtSchip > MaximumGewicht / 2)
            {
                return true;
            }

            return false;
        }
        public bool GewichtSchip(Container container)
        {
            if (MaximumGewicht == TotaalGewichtSchip + container.Gewicht)
            {
                TotaalGewichtSchip = container.Gewicht + TotaalGewichtSchip;
                return false;
            }

            return true;
        }
        public int yPossitie(Container container, int y)
        {
            if (y == 1)
            {
                return 0;
            }
            if (container.ContainerSoort == Container.Soort.Gekoeld)
            {
                return 0;
            }
            if (container.ContainerSoort == Container.Soort.WaardevolGekoeld)
            {
                return 0;
            }
            if (container.ContainerSoort == Container.Soort.Waardevol)
            {
                if (yEmpty)
                {
                    return y - 1;
                }
                return 0;
            }
            int positie = MiddelSortY + 1;
            if (positie >= y - 1)
            {
                positie = 1;
            }
            MiddelSortY = positie;

            return positie;
        }

        public int xPossitie()
        {
            Evenwicht();
            return 0;
        }

        public void Evenwicht()
        {
            int aantalcontainersLinks;
            int aantalcontainersRechts;
            string BreedteCheck;

            if (containerStapel.x % 2 == 0)
            {
                BreedteCheck = "Oneven";

            }

            else
            {
                BreedteCheck = "Even";
            }
        }
    }
}

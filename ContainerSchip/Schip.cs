using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContainerSchip
{
    public class Schip
    {
        public int MaximumGewicht { get; set; } = 800;
        public int ContainerFAIL { get; set; } = 0;

        private ContainerStapel containerStapel = new ContainerStapel();
        private int MiddelSortY;
        private bool yEmpty = true;
        private int TotaalGewichtSchip;
        private int GewichtOver;
        private bool Even;

        private int ZijdeBreedte;
        private int GewichtRechts;
        private int GewichtLinks;
        private int GewichtMidden;
        private int RijenLinks = 1;
        private int RijenRechts = 1;

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

        public int xPossitie(Container container, int x, int y)
        {
            if (x % 2 == 0) // even
            {
                Even = true;
                ZijdeBreedte = x / 2;

                int Zijde = Evenwicht(container);

                if (Zijde == 1)
                {
                    if (ContainerFAIL >= y * x)
                    {
                        RijenLinks++;
                    }
                    return ZijdeBreedte - RijenLinks; // links
                }
                if (ContainerFAIL >= y * x)
                {
                    RijenRechts++;
                }
                return ZijdeBreedte + (RijenRechts - 1); // rechts

            }
            else // oneven
            {
                ZijdeBreedte = (x - 1) / 2;
                if (ContainerFAIL < y)
                {
                    return ZijdeBreedte;
                }

                int Zijde = Evenwicht(container);


                if (Zijde == 1)
                {
                    if (ContainerFAIL >= y * (ZijdeBreedte + 1))
                    {
                        RijenLinks++;
                    }
                    return ZijdeBreedte - RijenLinks; // links
                }
                if (ContainerFAIL >= y * (ZijdeBreedte + 1))
                {
                    RijenRechts++;
                }
                return ZijdeBreedte + RijenRechts; // rechts
            }
        }

        public int Evenwicht(Container container)
        {
            double totaalGewicht = GewichtLinks + GewichtRechts + GewichtMidden;
            double maxVerschil = 0.2 * totaalGewicht;

            if (GewichtRechts + container.Gewicht - GewichtLinks <= maxVerschil)
            {
                return 0;
            }

            return 1;
        }

        public void VoegGewichtToe(Container container, int x)
        {
            if (Even)
            {
                if (x <= ZijdeBreedte - 1)
                {
                    GewichtLinks += container.Gewicht;
                }
                else if (x >= ZijdeBreedte)
                {
                    GewichtRechts += container.Gewicht;
                }
            }
            else
            {
                if (x < ZijdeBreedte)
                {
                    GewichtLinks += container.Gewicht;
                }
                else if (x > ZijdeBreedte)
                {
                    GewichtRechts += container.Gewicht;
                }
                else
                {
                    GewichtMidden += container.Gewicht;
                }
            }
        }
    }
}

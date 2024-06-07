using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchip
{
    public class ContainerStapel
    {
        public int aantalContainers { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public List<Container> containers { get; set; }
        public int stapelGewicht { get; set; }
        public bool eersteContainer { get; set; } = true;
        public bool waardevol { get; set; }
        public ContainerStapel() { }
        public ContainerStapel(int X, int Y, int AantalContainers, int StapelGewicht, bool EersteContainer, bool Waardevol)
        {
            x = X;
            y = Y;
            aantalContainers = AantalContainers;
            containers = new List<Container>();
            stapelGewicht = StapelGewicht;
            eersteContainer = EersteContainer;
            waardevol = Waardevol;
        }

        public ContainerStapel[,] grid;

        public void ContainerStapelsAanmaken()
        {
            grid = new ContainerStapel[y, x];
            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    ContainerStapel containerStapel = new ContainerStapel(xx, yy, aantalContainers, stapelGewicht, eersteContainer, waardevol);
                    grid[yy, xx] = containerStapel;
                }
            }
        }

        public bool VoegContainerToe(Container container)
        {
            if (stapelGewicht < 120 && stapelGewicht + container.Gewicht <= 120 && waardevol == false)
            {
                containers.Add(container);
                aantalContainers++;
                if (!eersteContainer)
                {
                    stapelGewicht = container.Gewicht + stapelGewicht;
                }

                if (container.ContainerSoort == Container.Soort.Waardevol ||
                    container.ContainerSoort == Container.Soort.WaardevolGekoeld)
                {
                    waardevol = true;
                }
                eersteContainer = false;
                return false;
            }
            return true;
        }

        public void ContainerStapelDisplay()
        {
            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    Console.Write(grid[yy, xx].aantalContainers + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

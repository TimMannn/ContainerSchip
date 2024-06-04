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
        public ContainerStapel() { }
        public ContainerStapel(int X, int Y, int AantalContainers)
        {
            x = X;
            y = Y;
            aantalContainers = AantalContainers;
            containers = new List<Container>();
            bool Waardevol = false;
        }

        public ContainerStapel[,] grid;

        public void ContainerStapelsAanmaken()
        {
            grid = new ContainerStapel[y, x];
            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    ContainerStapel containerStapel = new ContainerStapel(xx, yy, aantalContainers);
                    grid[yy, xx] = containerStapel;
                }
            }
        }

        public void VoegContainerToe(Container container)
        {
            containers.Add(container);
            aantalContainers++;
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

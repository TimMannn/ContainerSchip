using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchip
{
    public class Container
    {
        public int Gewicht { get; }
        public Soort ContainerSoort { get; }

        public enum Soort
        {
            Normaal,
            Waardevol,
            Gekoeld,
            WaardevolGekoeld

        }

        public Container(int gewicht, Soort soort)
        {
            Gewicht = gewicht;
            ContainerSoort = soort;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Car.EnumsCollections;

namespace Car
{
    public class Car
    {
        public string? Code { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public Types Type { get; set; }
        public int ModelYear { get; set; }
        public Colours Colour { get; set; }
        public int Cost { get; set; }
    }
}

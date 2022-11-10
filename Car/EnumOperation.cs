using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Car.EnumsCollections;

namespace Car
{
    public class EnumOperation
    {
        Car car = new Car();

        public void Colour(Colours number)
        {
            switch (number)
            {
                case Colours.Red:
                    car.Colour = Colours.Red;
                    break;
                case Colours.Green:
                    car.Colour = Colours.Green;
                    break;
                case Colours.Yellow:
                    car.Colour = Colours.Yellow;
                    break;
                case Colours.White:
                    car.Colour = Colours.White;
                    break;
                case Colours.Black:
                    car.Colour = Colours.Black;
                    break;
            }
        }
        public void Type(Types number)
        {
            switch (number)
            {
                case Types.Sedan:
                    car.Type = Types.Sedan;
                    break;
                case Types.Jeep:
                    car.Type = Types.Jeep;
                    break;
                case Types.Liftback:
                    car.Type = Types.Liftback;
                    break;
                case Types.Hetchbek:
                    car.Type = Types.Hetchbek;
                    break;
            }
        }

    }
}


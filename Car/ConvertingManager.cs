using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Car.EnumsCollections;

namespace Car
{
    internal class ConvertingManager
    {
        public Car ConvertStringToObject(string str)
        {
            Car car = new Car();

            string[] words = str.Split('|');
            car.Code = words[0];
            car.Brand = words[1];
            car.Model = words[2];
            //string CarType = car.Type.ToString();
            //CarType = words[3];
            //words[3] = car.Type.ToString();
            // car.Type = (Types)Convert.ChangeType(words[3], typeof(Types));
            car.Type = (Types)Enum.Parse(typeof(Types), words[3], true);
            car.ModelYear = Convert.ToInt32(words[4]);
            car.Colour = (Colours)Enum.Parse(typeof(Colours), words[5], true);
            car.Cost = Convert.ToInt32(words[6]);
            return car;
        }
        public string ConvertToString(Car car)
        {
            string Str_Car = string.Empty;

            Str_Car = Str_Car + car.Code.PadRight(5, ' ') + "|";
            Str_Car = Str_Car + car.Brand.PadRight(20, ' ') + "|";
            Str_Car = Str_Car + car.Model.PadRight(15, ' ') + "|";
            Str_Car = Str_Car + car.Type.ToString().PadRight(15, ' ') + "|";
            Str_Car = Str_Car + car.ModelYear.ToString().PadRight(4, ' ') + "|";
            Str_Car = Str_Car + car.Colour.ToString().PadRight(10, ' ') + "|";
            Str_Car = Str_Car + car.Cost.ToString().PadRight(8, ' ') + "|";
            return Str_Car;
        }
        public string ConvertListToString(List<Car> list)
        {
            string Str_Car = string.Empty;
            int index = 0;

            foreach (var item in list)
            {
                index = list.IndexOf(item);
            }

            foreach (var item in list)
            {
                int index2 = list.IndexOf(item);
                Str_Car = Str_Car + item.Code.PadRight(5, ' ') + "|";
                Str_Car = Str_Car + item.Brand.PadRight(20, ' ') + "|";
                Str_Car = Str_Car + item.Model.PadRight(15, ' ') + "|";
                Str_Car = Str_Car + item.Type.ToString().PadRight(15, ' ') + "|";
                Str_Car = Str_Car + item.ModelYear.ToString().PadRight(4, ' ') + "|";
                Str_Car = Str_Car + item.Colour.ToString().PadRight(10, ' ') + "|";

                if (index2 == index)
                {
                    Str_Car = Str_Car + item.Cost.ToString().PadRight(8, ' ') + "|";
                }
                else
                {
                    Str_Car = Str_Car + item.Cost.ToString().PadRight(8, ' ') + "|" + "\n";
                }
            }
            return Str_Car;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Checking
    {
        List<Car> list = new List<Car>();
        FileOperations fileOperations = new FileOperations();

        public Checking()
        {
            fileOperations.OpenFileAndReadToList(list);
        }
        public void CheckCode(string? code)
        {
            Car car = new Car();

            bool Answer = false;

            do
            {
                foreach (Car item in list)
                {

                    if (Convert.ToInt32(item.Code) == Convert.ToInt32(code))
                    {
                        Console.WriteLine("Please try again this code exist.");
                        code = Console.ReadLine();
                    }
                    else
                    {
                        Answer = true;
                    }
                }

                if (list.Count <= 0)
                {
                    Answer = true;
                }
            } while (Answer == false);
        }
        public int CheckNumber(int number)
        {
            bool check = false;


            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please insert number.");
                    check = true;
                }
                finally
                {
                    check = !check;
                }
            } while (check == false);

            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Car.EnumsCollections;


namespace Car
{
    internal class CarsDataManager
    {
        private ConvertingManager convertingManager = new ConvertingManager();
        FileOperations fileOperations = new FileOperations();
        List<Car> list = new List<Car>();

        public CarsDataManager()
        {
            fileOperations.OpenFileAndReadToList(list);
            DisplayAllCars();
        }
        public void DisplayCarsByCost()
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("1.From low to high.");
            Console.WriteLine("2.From high to low.");
            string? Answer = Console.ReadLine();

            if (Answer == "1")
            {
                list = list.OrderBy(x => x.Cost).ToList();
            }
            else if (Answer == "2")
            {
                list = list.OrderByDescending(x => x.Cost).ToList();
            }
            string StrList = convertingManager.ConvertListToString(list);
            Console.WriteLine(StrList);
        }
        public void DisplayCarsByFilters()
        {
            DisplayAllCars();

            Car car = new Car();

            Console.WriteLine("Please type car's brand which want to see.");
            Console.WriteLine("If you don't want type anything please type no.");
            string Carbrand = Console.ReadLine();
            Console.WriteLine("Please type car's model which want to see.");
            Console.WriteLine("If you don't want type anything please type no.");
            string CarModel = Console.ReadLine();
            Console.WriteLine("Please type car's type which want to see.");
            Console.WriteLine("If you don't want type anything please type no.");
            string CarType = Console.ReadLine();
            Console.WriteLine("Please type model's year which want to see.");
            Console.WriteLine("If you don't want type anything please type 0.");
            int CarModelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please type car's colour which want to see.");
            Console.WriteLine("If you don't want type anything please type no.");
            string CarColour = Console.ReadLine();
            Console.WriteLine("Please type car's cost which want to see.");
            Console.WriteLine("If you don't want type anything please type 0.");
            int CarCost = Convert.ToInt32(Console.ReadLine());

            if (Carbrand != "no")
            {
                list = list.Where(x => x.Brand == Carbrand.PadRight(20, ' ')).ToList();
            }
            if (CarModel != "no")
            {
                list = list.Where(x => x.Model == CarModel).ToList();
            }
            if (CarType != "no")
            {
                list = list.Where(x => Convert.ToString(x.Type) == CarType).ToList();
            }
            if (CarModelYear != 0)
            {
                list = list.Where(x => x.ModelYear == CarModelYear).ToList();
            }
            if (CarColour != "no")
            {
                list = list.Where(x => Convert.ToString(x.Colour) == CarColour).ToList();
            }
            if (CarCost != 0)
            {
                list = list.Where(x => x.Cost == CarCost).ToList();
            }

            DisplayAllCars();
            list = list.Where(x => x.Cost > 0).ToList();
        }
        public void DisplayAllCars()
        {
            string StrList = convertingManager.ConvertListToString(list);
            Console.WriteLine(StrList);
        }
        public void SelectbyCodeAndDelete(string code)
        {
            var itemToRemove = list.SingleOrDefault(r => r.Code == code);

            if (itemToRemove != null)
                list.Remove(itemToRemove);
            string StrList = convertingManager.ConvertListToString(list);
            fileOperations.OpenFileAndUpdate(StrList);
        }
        public void InsertCar()
        {
            Checking checking = new Checking();
            EnumOperation enumOperation = new EnumOperation();
            Car car = new Car();
            Console.WriteLine("Please insert code of car.");
            car.Code = Console.ReadLine();

            checking.CheckCode(car.Code);

            Console.WriteLine("Please insert brand of car.");
            car.Brand = Console.ReadLine();
            Console.WriteLine("Please insert model of car.");
            car.Model = Console.ReadLine();
            Console.WriteLine("Choose type of car.");
            Console.WriteLine("1.Sedan.");
            Console.WriteLine("2.Jeep.");
            Console.WriteLine("3.Liftback.");
            Console.WriteLine("4.Hetchback.");

            int choosenTypeNumber = Convert.ToInt32(Console.ReadLine());
            //enumOperation.Type((Types)choosenTypeNumber);
            car.Type = (Types)choosenTypeNumber;

            Console.WriteLine("Please insert model year of car.");
            car.ModelYear = checking.CheckNumber(car.ModelYear);

            Console.WriteLine("Choose colour of car.");
            Console.WriteLine("1.Red.");
            Console.WriteLine("2.Green.");
            Console.WriteLine("3.Yellow.");
            Console.WriteLine("4.White.");
            Console.WriteLine("5.Black.");

            int choosenColourNumber = Convert.ToInt32(Console.ReadLine());
            //enumOperation.Colour((Colours)choosenColourNumber);
            car.Colour = (Colours)choosenColourNumber;

            Console.WriteLine("Please insert cost of car.");
            car.Cost = checking.CheckNumber(car.Cost);

            list.Add(car);

            string Str_Product = convertingManager.ConvertToString(car);
            // OpenFileAndWrite(Str_Product);
            fileOperations.OpenFileAndWrite(Str_Product);

            DisplayAllCars();
        }
        public void UpdateCar()
        {
            Checking checking = new Checking();
            EnumOperation enumOperation = new EnumOperation();
            Car car = new Car();

            Console.WriteLine("Please type car's code which want to update.");
            string Code_Update = Console.ReadLine();
            SelectbyCodeAndDelete(Code_Update.PadRight(5, ' '));
            car.Code = Code_Update;

            Console.WriteLine("Please enter new brand of car.");
            car.Brand = Console.ReadLine();

            Console.WriteLine("Please enter new model of car.");
            car.Model = Console.ReadLine();

            Console.WriteLine("Please enter new type of car.");
            Console.WriteLine("1.Sedan.");
            Console.WriteLine("2.Jeep.");
            Console.WriteLine("3.Liftback.");
            Console.WriteLine("4.Hetchback.");
            int choosenTypesNumber = Convert.ToInt32(Console.ReadLine());
            car.Type = (Types)choosenTypesNumber;

            Console.WriteLine("Please enter new  year of car.");
            car.ModelYear = checking.CheckNumber(car.ModelYear);

            Console.WriteLine("Please enter new colour of car.");
            Console.WriteLine("1.Red.");
            Console.WriteLine("2.Green.");
            Console.WriteLine("3.Yellow.");
            Console.WriteLine("4.White.");
            Console.WriteLine("5.Black.");
            int choosenColourNumber = Convert.ToInt32(Console.ReadLine());
            car.Colour = (Colours)choosenColourNumber;

            Console.WriteLine("Please enter new cost of car.");
            car.Cost = checking.CheckNumber(car.Cost);

            list.Add(car);

            string StrList = convertingManager.ConvertListToString(list);
            //OpenFileAndUpdate(StrList);
            fileOperations.OpenFileAndUpdate(StrList);

            DisplayAllCars();
        }
        public void DeleteCar()
        {
            DisplayAllCars();

            Console.WriteLine(" Please type car's code which want to delete.");
            string Code_Delete = Console.ReadLine();
            SelectbyCodeAndDelete(Code_Delete.PadRight(5, ' '));

            string StrList = convertingManager.ConvertListToString(list);
            //OpenFileAndUpdate(StrList);
            fileOperations.OpenFileAndUpdate(StrList);

            DisplayAllCars();
        }
    }
}
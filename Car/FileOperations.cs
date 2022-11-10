using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class FileOperations
    {
        private ConvertingManager convertingManager = new ConvertingManager();
        public List<Car> list = new List<Car>();
        readonly string path_ = @"C:\Users\user\Desktop\Cars.txt";

        public FileOperations()
        {
            if (!File.Exists(path_))
            {
                File.Create(path_).Close();
            }
        }

        public void OpenFileAndWrite(string Str_Car)
        {
            // string Path = "@example.txt";
            using StreamWriter sw = new(path_, append: true);
            sw.WriteLine(Str_Car);
        }

        public void OpenFileAndUpdate(string Str_Car)
        {
            // string Path = "@example.txt";
            File.Delete(path_);
            // Path.Remove(Convert.ToInt32(Path));
            OpenFileAndWrite(Str_Car);
        }

        public void OpenFileAndReadToList(List<Car> list)
        {
            string[] line = File.ReadAllLines(path_);

            foreach (var item in line)
            {
                Car car = convertingManager.ConvertStringToObject(item);
                list.Add(car);
            }
        }
    }
}

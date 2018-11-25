using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Car
    {
        private int nwheels;
        private string brand;
        public string color;

        public Car(string brand_)
        {
            brand = brand_;
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            //set
            //{
            //    brand = value;
            //}
        }


        public string GetBrand()
        {
            return brand;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car("Suzuki");
            c.color = "red";
            //c.Brand = "Audi";
            Console.WriteLine(c.Brand);
            Console.ReadLine();
        }
    }
}

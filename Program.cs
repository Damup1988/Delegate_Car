using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Car NewCar = new Car
            {
                Model = "BMW",
                MaxSpeed = 150,
                CurSpeed = 0,
                CarIsDead = false
            };


            Car BMW = new Car(300, 150, "BMW Z4", false);
            //Lambda expressions
            NewCar.Notify += mes => Console.WriteLine(mes);
            BMW.Notify += mes => Console.WriteLine(mes);

            for(int i = 0; i < 10; i++)
            {
                NewCar.SpeedUp(20);
            }

            for (int i = 0; i < 20; i++)
            {
                BMW.SpeedDown(10);
            }

            Console.WriteLine("For Git v2");
            Console.ReadLine();
        }
    }
}

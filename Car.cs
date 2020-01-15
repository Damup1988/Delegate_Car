using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Car
    {
        //Our delegate
        public delegate void CarStateHandler(string Message);
        //Our event
        public event CarStateHandler Notify;

        public int MaxSpeed { get; set; }
        public int CurSpeed { get; set; }
        public string Model { get; set; }
        public bool CarIsDead { get; set; }
        public bool CarIsMoving { get; set; }

        public Car()
        {

        }

        public Car(int MaxSpeed, int CurSpeed, string Model, bool CarIsDead)
        {
            this.CurSpeed = CurSpeed;
            this.MaxSpeed = MaxSpeed;
            this.Model = Model;
            this.CarIsDead = CarIsDead;
            if(this.CurSpeed > 0)
            {
                CarIsMoving = true;
            }
        }

        public void SpeedUp(int delta)
        {
            if (!CarIsDead)
            {
                CurSpeed += delta;
                Notify?.Invoke($"Current spped is {CurSpeed}");
                if (MaxSpeed - CurSpeed < 20 & MaxSpeed - CurSpeed > 0)
                {
                    Notify?.Invoke($"Current spped is {CurSpeed}. The car is going to blow!");
                }
                if (CurSpeed > MaxSpeed)
                {
                    Notify?.Invoke("The car has blown!");
                    CarIsDead = true;
                }
            }
            else
            {
                Notify?.Invoke($"{Model} is dead!");
            }
        }

        public void SpeedDown (int delta)
        {
            if (CarIsMoving)
            {
                CurSpeed -= delta;
                Notify?.Invoke($"Current spped of {Model} is {CurSpeed}");
                if (CurSpeed <= 0)
                {
                    Notify?.Invoke($"{Model} has stopped");
                    CarIsMoving = false;
                }
            }
            else
            {
                Notify?.Invoke($"{Model} isn't moving");
            }

        }
    }
}

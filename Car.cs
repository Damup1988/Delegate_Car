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

        //Exemplar of the delegate
        CarStateHandler mes;

        //Registration of the delegate mes
        public void RegHandler(CarStateHandler mes)
        {
            this.mes += mes;
        }

        public void UnregHandler(CarStateHandler mes)
        {
            this.mes -= mes;
        }

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
                if (mes != null)
                    mes($"Current spped is {CurSpeed}");
                if (MaxSpeed - CurSpeed < 20 & MaxSpeed - CurSpeed > 0)
                {
                    if (mes != null)
                        mes($"Current spped is {CurSpeed}. The car is going to blow!");
                }
                if (CurSpeed > MaxSpeed)
                {
                    if (mes != null)
                        mes("The car has blown!");
                    CarIsDead = true;
                }
            }
            else
            {
                if (mes != null)
                    mes($"{Model} is dead!");
            }
        }

        public void SpeedDown (int delta)
        {
            if (CarIsMoving)
            {
                CurSpeed -= delta;
                if (mes != null)
                    mes($"Current spped of {Model} is {CurSpeed}");
                if (CurSpeed <= 0)
                {
                    if (mes != null)
                        mes($"{Model} has stopped");
                    CarIsMoving = false;
                }
            }
            else
            {
                    mes?.Invoke($"{Model} isn't moving");
            }

        }
    }
}

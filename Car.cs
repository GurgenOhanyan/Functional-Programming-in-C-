using System;
using System.Collections.Generic;
using System.Text;

namespace Functional_Programming
{
    class Car
    {
        public delegate void CarEvent(string message);

        private int speed;

        private readonly int maxSpeed;

        private CarEvent carEventHandler;

        public Car(int maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }

        public int Speed => speed;

      
        public void RegisterCarEventHandler(CarEvent handler)
        {
            this.carEventHandler += handler;
        }

        public void Accelerate(int delta)
        {
           
            if (this.speed == 0 && delta > 0)
                if (this.carEventHandler != null)
                    this.carEventHandler("INFO: Car started to move.");

            this.speed += delta;

            if (this.speed >= this.maxSpeed)
            {
                this.carEventHandler?.Invoke("WARNING: Max speed is reached");
                this.speed = this.maxSpeed;
            }

            if (this.speed == 0)
                this.carEventHandler?.Invoke("INFO: Car is stopped");
        }

        public void DeregisterCarEventHandler(CarEvent handler)
        {
            this.carEventHandler -= handler;
        }

    }
}

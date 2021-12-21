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

        //Car Classi Carevent tipy hghvum e 2 funcionneri vra voroc poxancum e car-i mejic ir parametrery (info nery ) voric  heto
        //\callback e katarvum trvac metodnerin, ashxatum en dranq aynuhetev \car classi objekti hamar e katarvum iren hamapatsaxan ashxatanqy:
        public void RegisterCarEventHandler(CarEvent handler)
        {
            this.carEventHandler += handler;
        }

        public void Accelerate(int delta)
        {
            //carevent handleri mej sa carevent delegate tipi popoxakan e , hetevabar nran poxancelov anhrajesht parametry, 
            //ayn metodneri vra voronc vra ayn hxvel er hertov kanchvum en , stanalov anhrajesht parametrery, e anmijapes 
            //ashxatum en ayd metodnery
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

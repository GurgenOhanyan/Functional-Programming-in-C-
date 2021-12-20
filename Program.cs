using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programming
{
    class Program
    {
        public delegate void PrintDelegate(string message);

        private static void PrintMethod(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {

            Car car = new Car(60);

            car.RegisterCarEventHandler(OnCarEvent);
            //Registering Second method referance  
            car.RegisterCarEventHandler(AnotherCarEvent);
            for (int i = 0; i < 3; i++)
            {
                car.Accelerate(20);
                Console.WriteLine($"Car Speed -- {car.Speed}");
            }
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < 3; i++)
            {
                car.Accelerate(-20);
                Console.WriteLine($"Car Speed -- {car.Speed}");
            }
            // ===========================

            //Func<int, int, int> mathAdd = (int x, int y) => x + y;
            //Func<int, int> mathAbs =
            //    (int x) =>
            //    {
            //        if (x < 0)
            //            return -x;
            //        else
            //            return x;
            //    };

            List<int> numbers = new List<int> { 42, 17, 65, 24, 31, 6, 58, 0 };
            Predicate<int> isEvenPredicate = new Predicate<int>(Program.IsEvenNumber);
            List<int> evenNumbers = numbers.FindAll(isEvenPredicate);
            foreach (int number in evenNumbers)
                Console.Write($"{number}, ");
            Console.WriteLine();


            //Lambda instead of delegate
            List<int> evenNumbersWithLambda = numbers.FindAll(n => n % 2 == 0);

        }
        private static bool IsEvenNumber(int x)
        {
            return x % 2 == 0;
        }
        static void OnCarEvent(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void AnotherCarEvent(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

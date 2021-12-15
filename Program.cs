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
            //Console.WriteLine("--------------------------------------------");
            //for (int i = 0; i < 5; i++)
            //{
            //    car.Accelerate(-10);
            //    Console.WriteLine($"Car Speed -- {car.Speed}");
            //}
            // C# 1.0
            PrintDelegate print1 = new PrintDelegate(Program.PrintMethod);

            // C# 2.0
            //Anonymous function
            PrintDelegate print2 = delegate (string msg) { Console.WriteLine(msg); };

            // C# 3.0
            //Lambda Expression
            PrintDelegate print3 = (string msg) => Console.WriteLine(msg);

            print1("Hello");
            print2("C Sharp");
            print3("Language");

            // ===========================

            Func<int, int, int> mathAdd = (int x, int y) => x + y;
            Func<int, int> mathAbs =
                (int x) =>
                {
                    if (x < 0)
                        return -x;
                    else
                        return x;
                };

            List<int> numbers = new List<int> { 42, 17, 65, 24, 31, 6, 58, 0 };
            Predicate<int> isEvenPredicate = new Predicate<int>(Program.IsEvenNumber);
            List<int> evenNumbers = numbers.FindAll(isEvenPredicate);
            foreach (int number in evenNumbers)
                Console.Write($"{number}, ");
            Console.WriteLine();


            //Lambda instead of delegate
            List<int> evenNumbersWithLambda = numbers.FindAll(n => n % 2 == 0);


            //LINQ
            IEnumerable<ChessPlayer> players = ChessPlayer.GetChessPlayersList();

            var topFivePlayers = players.OrderByDescending(x => x.Rating)
                                    .ThenBy(x => x.FirstName)
                                    .Take(5);

            var filtered = players.Where(x => x.BirthYear > 1980);

            //
            IEnumerable<Tournament> tournaments = Tournament.GetDemoStats();
            IEnumerable<ChessPlayer> chessPlayers = ChessPlayer.GetChessPlayersList();

            //Տպել մրցաշարերում հաղթող երկրներից որը քանի անգամ է հաղթել։
            //var winnerCountyCount = chessPlayers.Join(tournaments, player => player.Id, tournament => tournament.PlayerId, (player, tounmament) =>
            //                {
                               
            //                }
            // );








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
    class ChessPlayer
    {
        private int birthYear;
        public int BirthYear
        {
            get
            {
                //Console.WriteLine(birthYear);
                return this.birthYear;
            }

            set
            {
                this.birthYear = value;
            }
        }


        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Rating { get; set; }

        public string Country { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Country}, Born in {BirthYear}";
        }

        public static IEnumerable<ChessPlayer> GetChessPlayersList()
        {
            return new List<ChessPlayer>()
            {
                new ChessPlayer()
                {
                    Id = 1,
                    BirthYear = 1990,
                    FirstName = "Magnus",
                    LastName = "Carlsen",
                    Rating = 2862,
                    Country = "NOR"
                },
                new ChessPlayer()
                {
                    Id = 2,
                    BirthYear = 1992,
                    FirstName = "Fabiano",
                    LastName = "Caruana",
                    Rating = 2823,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 4,
                    BirthYear = 1992,
                    FirstName = "Liren",
                    LastName = "Ding",
                    Rating = 2791,
                    Country = "CHN"
                },
                new ChessPlayer()
                {
                    Id = 5,
                    BirthYear = 1994,
                    FirstName = "Anish",
                    LastName = "Giri",
                    Rating = 2764,
                    Country = "NED"
                },
                new ChessPlayer()
                {
                    Id = 6,
                    BirthYear = 1993,
                    FirstName = "Wesley",
                    LastName = "So",
                    Rating = 2770,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 7,
                    BirthYear = 1975,
                    FirstName = "Vladimir",
                    LastName = "Kramnik",
                    Rating = 2753,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 8,
                    BirthYear = 1990,
                    FirstName = "Maxime",
                    LastName = "Vachier-Lagrave",
                    Rating = 2784,
                    Country = "FRA"
                },
                new ChessPlayer()
                {
                    Id = 9,
                    BirthYear = 1987,
                    FirstName = "Hikaru",
                    LastName = "Nakamura",
                    Rating = 2736,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 10,
                    BirthYear = 1990,
                    FirstName = "Sergey",
                    LastName = "Karjakin",
                    Rating = 2789,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 11,
                    BirthYear = 1990,
                    FirstName = "Ian",
                    LastName = "Nepomniachtchi",
                    Rating = 2789,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 12,
                    BirthYear = 1969,
                    FirstName = "Anand",
                    LastName = "Viswanathan",
                    Rating = 2753,
                    Country = "IND"
                },
                new ChessPlayer()
                {
                    Id = 13,
                    BirthYear = 1982,
                    FirstName = "Levon",
                    LastName = "Aronian",
                    Rating = 2781,
                    Country = "ARM"
                },
            };
        }
    }
    class Tournament
    {
        public int PlayerId { get; set; }
        public string Title { get; set; }
        public int TakenPlace { get; set; }
        public string Country { get; set; }

        public static IEnumerable<Tournament> GetDemoStats()
        {
            return new List<Tournament>()
            {
                new Tournament() { Country = "Germany", PlayerId = 1, TakenPlace = 1, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 1, TakenPlace = 3, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 1, TakenPlace = 2, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 2, TakenPlace = 2, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 2, TakenPlace = 1, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 2, TakenPlace = 1, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 3, TakenPlace = 5, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 3, TakenPlace = 9, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 3, TakenPlace = 5, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 4, TakenPlace = 4, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 4, TakenPlace = 6, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 4, TakenPlace = 3, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 5, TakenPlace = 7, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 5, TakenPlace = 2, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 5, TakenPlace = 4, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 6, TakenPlace = 3, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 6, TakenPlace = 8, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 6, TakenPlace = 8, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 7, TakenPlace = 9, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 7, TakenPlace = 10, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 7, TakenPlace = 7, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 8, TakenPlace = 6, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 8, TakenPlace = 4, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 8, TakenPlace = 9, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 9, TakenPlace = 8, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 9, TakenPlace = 5, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 9, TakenPlace = 10, Title = "Tournament 3"},
                new Tournament() { Country = "Germany", PlayerId = 10, TakenPlace = 10, Title = "Tournament 1"},
                new Tournament() { Country = "USA", PlayerId = 10, TakenPlace = 7, Title = "Tournament 2"},
                new Tournament() { Country = "Russia", PlayerId = 10, TakenPlace = 6, Title = "Tournament 3"},
            };
        }
    }
}

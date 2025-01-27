using System.Collections.Generic;
using System.Globalization;
using System;

namespace The_Cinema
{
    class Cinema
    {
        string genre;
        string name;
        string description;
        TimeSpan runtime;
        double ticket;

        public Cinema()
        {

        }

        public Cinema(string genre, string name, string description, TimeSpan runtime, double ticket)
        {
            this.Genre = genre;
            this.Name = name;
            this.Desc = description;
            this.Runtime = runtime;
            this.Ticket = ticket;
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Desc
        {
            get { return description; }
            set { description = value; }
        }

        public TimeSpan Runtime
        {
            get { return runtime; }
            set { runtime = value; }
        }

        public double Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cinema> cinema = new List<Cinema>();
            string clientOrEmployee;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome To Galaxy Cinemas");
                Console.WriteLine("***************************************");
                Console.ResetColor();
                Console.Write("Are You A Client or an Employee (Type 'Exit' to Quit): ");
                clientOrEmployee = Console.ReadLine();

                if (String.Equals(clientOrEmployee, "Client", StringComparison.OrdinalIgnoreCase))
                {
                    HandleClient(cinema);
                }
                else if (String.Equals(clientOrEmployee, "Employee", StringComparison.OrdinalIgnoreCase))
                {
                    HandleEmployee(cinema);
                }
                else if (!String.Equals(clientOrEmployee, "Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input, please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (!String.Equals(clientOrEmployee, "Exit", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Thank you for using Galaxy Cinemas. Goodbye!");
        }

        static void HandleClient(List<Cinema> cinema)
        {
            int option;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Client Menu");
                Console.WriteLine("***************************************");
                Console.ResetColor();
                Console.WriteLine("1) Display Movies");
                Console.WriteLine("2) Purchase Ticket For Film");
                Console.WriteLine("3) Buying Snacks");
                Console.WriteLine("4) Logout");
                Console.Write("Select Option: ");

                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
                {
                    Console.WriteLine("Please Enter Valid Input");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("******************************************");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("1) Display Movies");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Genres\t\tName\t\tDescription\tRuntime\tTicketPrice$");

                        foreach (Cinema item in cinema)
                        {
                            Console.WriteLine($"{item.Genre}\t\t{item.Name}\t\t{item.Desc}\t\t{item.Runtime}\t\t{item.Ticket}");
                        }
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Tickets purchased successfully.");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Snacks purchased successfully.");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Logging out...");
                        break;
                }

            } while (option != 4);
        }

        static void HandleEmployee(List<Cinema> cinema)
        {
            int option;
            int limit = 0;
            bool filmFull = false;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Employee Menu");
                Console.WriteLine("***************************************");
                Console.ResetColor();
                Console.WriteLine("1) Create Movies");
                Console.WriteLine("2) Display Movies");
                Console.WriteLine("3) Logout");
                Console.Write("Select Option: ");

                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
                {
                    Console.WriteLine("Please Enter Valid Input");
                }

                switch (option)
                {
                    case 1:
                        if (!filmFull)
                        {
                            Cinema films = new Cinema();

                            Console.Write("Enter Movie Genre: ");
                            films.Genre = Console.ReadLine();

                            Console.Write("Enter Movie Name: ");
                            films.Name = Console.ReadLine();

                            Console.Write("Enter Movie Description: ");
                            films.Desc = Console.ReadLine();

                            Console.Write("Enter Movie Runtime (hh:mm:ss): ");
                            films.Runtime = TimeSpan.ParseExact(Console.ReadLine(), @"h\:mm\:ss", CultureInfo.InvariantCulture);

                            Console.Write("Enter Movie Ticket Price: ");
                            films.Ticket = double.Parse(Console.ReadLine());

                            cinema.Add(films);
                            limit++;
                            filmFull = limit >= 20;

                            Console.WriteLine("Movie has been created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Movie creation limit reached.");
                        }
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("******************************************");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("2) Display Movies");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Genres\t\tName\t\tDescription\tRuntime\tTicketPrice$");

                        foreach (Cinema item in cinema)
                        {
                            Console.WriteLine($"{item.Genre}\t\t{item.Name}\t\t\t{item.Desc}\t{item.Runtime}\t{item.Ticket}");
                        }
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Logging out...");
                        break;
                }

            } while (option != 3);
        }
    }
}

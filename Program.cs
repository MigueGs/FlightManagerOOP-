/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
    internal class Program
    {
        /* 
         * RDMS AIRLINES FLIGHT MANAGEMENT SYSTEM 
         */

        static FlightManager fm = new FlightManager(1, 100);
        static CustomerManager cm = new CustomerManager(1, 100);
        static BookingManager bm = new BookingManager(1, 100);

        static Coordinator coord = new Coordinator(fm, cm, bm);

        //----------------------------------------------- MAIN MENU ---------------------------// BULLETPROOFED[x]
        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("RDMS Airlines Limited");
            Console.WriteLine("Please select a choice from the coice below:");
            Console.WriteLine(" 1: Flights");
            Console.WriteLine(" 2: Customers");
            Console.WriteLine(" 3: Bookings\n");
            Console.WriteLine(" 4: Exit");

            int input;

            try
            {
                input = int.Parse(Console.ReadLine());
                ProcessMainMenuOption(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                mainMenu();
            }
        }

        private static void ProcessMainMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    flightMenu();
                    break;
                case 2:
                    Console.Clear();
                    customerMenu();
                    break;
                case 3:
                    Console.Clear();
                    bookingMenu();
                    break;
                case 4:
                    ExitWithFinesse();
                    break;
                default:
                    Console.WriteLine("Please input a valid option...");
                    mainMenu();
                    break;
            }
        }




        //----------------------------------------------- FLIGHT ---------------------------// BULLETPROOFED[x] [X][X][X][X]
        public static void flightMenu()
        {
            Console.Clear();
            Console.WriteLine("RDMS Airlines Limited");
            Console.WriteLine(" Flight Menu");
            Console.WriteLine("Please select a choice from the coice below:");
            Console.WriteLine(" 1: Add Flight");
            Console.WriteLine(" 2: View all flights");
            Console.WriteLine(" 3: View a particular flight");
            Console.WriteLine(" 4: Delete a flight\n");
            Console.WriteLine(" 5: Back to main menu");

            int input;

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine("RDMS Airlines Limited");
                Console.WriteLine(" Flight Menu");
                Console.WriteLine("Please select a choice from the coice below:");
                Console.WriteLine(" 1: Add Flight");
                Console.WriteLine(" 2: View all flights");
                Console.WriteLine(" 3: View a particular flight");
                Console.WriteLine(" 4: Delete a flight\n");
                Console.WriteLine(" 5: Back to main menu");
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    addFlight();
                    break;
                case 2:
                    Console.Clear();
                    printAllFlights();
                    break;
                case 3:
                    Console.Clear();
                    printFlight();
                    break;
                case 4:
                    Console.Clear();
                    deleteFlight();
                    break;
                case 5:
                    Console.Clear();
                    mainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please input a valid option");
                    flightMenu();
                    break;
            }
        }



        //1 .Add flight
        //addFlight(string origin, string destination, int maxSeats) //---------------------//BULLETPROOFED[x]

        public static void addFlight()
        {
            string origin, destination;
            int maxSeats;

            Console.WriteLine("*----- Register a flight ------*");

            // Validate origin
            do
            {
                Console.WriteLine("\nPlease input the origin:");
                origin = Console.ReadLine().Trim(); // Trim to remove leading and trailing spaces

                if (string.IsNullOrEmpty(origin))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Origin cannot be empty.");
                }

            } while (string.IsNullOrEmpty(origin));

            // Validate destination
            do
            {
                Console.WriteLine("\nPlease input the destination:");
                destination = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(destination))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Destination cannot be empty.");
                }

            } while (string.IsNullOrEmpty(destination));

            // Validate maxSeats
            bool validInput = false;
            do
            {
                Console.WriteLine("\nPlease input the maximum number of seats:");

                if (int.TryParse(Console.ReadLine(), out maxSeats) && maxSeats > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for maximum seats.");
                }

            } while (!validInput);

            if (coord.addFlight(origin, destination, maxSeats))
            {
                Console.Clear();
                Console.WriteLine("\nFlight added successfully!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nCannot add flight, memory is full!\n");
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            flightMenu();
        }





        //2. View a particular flight     //-------------------------------------//BULLETPROOFED[x]
        public static void printFlight()
        {
            int flightID;

            Console.WriteLine(coord.viewAllFlights());

            bool validInput = false;

            do
            {
                Console.WriteLine("\nPlease input the flight ID: ");

                if (int.TryParse(Console.ReadLine(), out flightID) && flightID > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid integer for flight ID.");
                }

            } while (!validInput);

            Console.Clear();

            Console.WriteLine(coord.viewFlight(flightID));

            Console.WriteLine(coord.GetAllCustomersInFlight(flightID));

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            flightMenu();
        }


        //3. View all flight listings    //---------------------------------------//BULLETPROOFED[x]
        public static void printAllFlights()
        {
            string flightsInfo = coord.viewAllFlights();

            if (flightsInfo != null)
            {
                Console.WriteLine(flightsInfo);
            }
            else
            {
                Console.WriteLine("Error retrieving flight information. Please try again later.");
            }

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey(true); // Use true to prevent displaying the pressed key
            flightMenu();
        }

        public static void deleteFlight() //----------------------------------------//BULLETPROOFED[x]
        {
            int flightID;

            Console.WriteLine("*DELETE A FLIGHT*");

            bool validInput = false;

            do
            {
                Console.WriteLine("Please input the flight ID:");

                if (int.TryParse(Console.ReadLine(), out flightID) && flightID > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for flight ID.");
                }

            } while (!validInput);

            var existingFlight = coord.flightExists(flightID);

            if (existingFlight != null)
            {
                Console.WriteLine(existingFlight);

                Console.WriteLine("\n *Are you sure you want to delete this flight?* [Y/N]?");
                string input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    Console.WriteLine(coord.deleteFlight(flightID));
                }
                else
                {
                    Console.WriteLine("Process canceled.");
                }
            }
            else
            {
                Console.WriteLine("Flight not found. Deletion aborted.");
            }

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey(true); // Use true to prevent displaying the pressed key
            flightMenu();
        }



        //----------------------------------------------- CUSTOMER ---------------------------//    BULLETPROOFED[X] [X][X][X][X]
        //Main Customer Menu
        public static void customerMenu()
        {
            Console.Clear();
            Console.WriteLine("RDMS Airlines Limited");
            Console.WriteLine(" Customer Menu");
            Console.WriteLine("Please select a choice from the coice below:");
            Console.WriteLine(" 1: Add customer");
            Console.WriteLine(" 2: View all customers");
            Console.WriteLine(" 3: View a particular customer");
            Console.WriteLine(" 4: Delete a customer\n");
            Console.WriteLine(" 5: Back to main menu");

            int input;

            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
            {
                Console.Clear();
                Console.WriteLine("RDMS Airlines Limited");
                Console.WriteLine(" Customer Menu");
                Console.WriteLine("Please select a valid option (1-5).");
                Console.WriteLine(" 1: Add customer");
                Console.WriteLine(" 2: View all customers");
                Console.WriteLine(" 3: View a particular customer");
                Console.WriteLine(" 4: Delete a customer\n");
                Console.WriteLine(" 5: Back to main menu");
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    addCustomer();
                    break;
                case 2:
                    Console.Clear();
                    printAllCustomers();
                    break;
                case 3:
                    Console.Clear();
                    printCustomer();
                    break;
                case 4:
                    Console.Clear();
                    deleteCustomer();
                    break;
                case 5:
                    Console.Clear();
                    mainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please input a valid option");
                    customerMenu();
                    break;
            }
        }



        //1. Add Customer //------------------------------------------//BULLETPROOFED[x]
        public static void addCustomer()
        {
            string firstName, lastName, phoneNumber;

            Console.WriteLine("*---- Register a Customer ------*");

            // Validate First Name
            do
            {
                Console.WriteLine("\nPlease input the First Name:");
                firstName = Console.ReadLine().Trim(); // Trim to remove leading and trailing spaces

                if (string.IsNullOrEmpty(firstName))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. First Name cannot be empty.");
                }

            } while (string.IsNullOrEmpty(firstName));

            // Validate Last Name
            do
            {
                Console.WriteLine("\nPlease input the Last Name:");
                lastName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(lastName))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Last Name cannot be empty.");
                }

            } while (string.IsNullOrEmpty(lastName));

            // Validate Phone Number
            do
            {
                Console.WriteLine("\nPlease input a phone number:");
                phoneNumber = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Phone Number cannot be empty.");
                }

            } while (string.IsNullOrEmpty(phoneNumber));

            if (coord.addCustomer(firstName, lastName, phoneNumber))
            {
                Console.Clear();
                Console.WriteLine("Customer added successfully!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot add customer, memory is full!");
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            customerMenu();
        }


        //2. View a particular Customer  //---------------------------------------//BULLETPROOFED[x]
        public static void printCustomer()
        {
            Console.WriteLine("*---- Customer search ----*");
            int customerID;

            bool validInput = false;

            do
            {
                Console.WriteLine("Please input the Customer ID: ");

                if (int.TryParse(Console.ReadLine(), out customerID) && customerID > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for Customer ID.");
                }

            } while (!validInput);

            Console.WriteLine(coord.viewCustomer(customerID));

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            customerMenu();
        }


        //3. View all Customers   //-------------------------------------------//BULLETPROOFED[x]
        public static void printAllCustomers()
        {
            Console.WriteLine(coord.viewAllCustomers());

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            customerMenu();
        }

        //4. Delete Customer     //---------------------------------------------//BULLETPROOFED[x]
        public static void deleteCustomer()
        {
            int customerID;
            Console.WriteLine("*DELETE A CUSTOMER*");

            bool validInput = false;

            do
            {
                Console.WriteLine("Please input the Customer ID:");

                if (int.TryParse(Console.ReadLine(), out customerID) && customerID > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for Customer ID.");
                }

            } while (!validInput);

            if (coord.viewCustomer(customerID) == null) {
                Console.WriteLine("Customer not found...");

                Console.WriteLine("\n\nPress any key to go back...");
                Console.ReadKey();
                customerMenu();
            }

            Console.WriteLine(coord.viewCustomer(customerID));
            Console.WriteLine("\n *Are you sure you want to delete this customer?* [Y/N]?");
            string input;

            do
            {
                input = Console.ReadLine().Trim().ToUpper(); // Convert to uppercase to handle both lower and upper case input

                if (input != "Y" && input != "N")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }

            } while (input != "Y" && input != "N");

            if (input == "Y")
            {
                Console.WriteLine(coord.deleteCustomer(customerID));
            }
            else
            {
                Console.WriteLine("Process canceled.");
            }

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            customerMenu();
        }




        //----------------------------------------------- BOOKING ---------------------------// BULLETPROOFED[x] [X][X][X][X]
        //Main booking Menu
        public static void bookingMenu()
        {
            Console.Clear();
            Console.WriteLine("RDMS Airlines Limited");
            Console.WriteLine(" Booking Menu");
            Console.WriteLine("Please select a choice from the coice below:");
            Console.WriteLine(" 1: Add booking");
            Console.WriteLine(" 2: View all bookings");
            Console.WriteLine(" 3: View a particular booking");
            Console.WriteLine(" 4: Delete a booking\n");
            Console.WriteLine(" 5: Back to main menu");

            int input;

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine("RDMS Airlines Limited");
                Console.WriteLine(" Booking Menu");
                Console.WriteLine("Please select a choice from the coice below:");
                Console.WriteLine(" 1: Add booking");
                Console.WriteLine(" 2: View all bookings");
                Console.WriteLine(" 3: View a particular booking");
                Console.WriteLine(" 4: Delete a booking\n");
                Console.WriteLine(" 5: Back to main menu");
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    addBooking();
                    break;
                case 2:
                    Console.Clear();
                    printAllBookings();
                    break;
                case 3:
                    Console.Clear();
                    printBooking();
                    break;
                case 4:
                    Console.Clear();
                    deleteBooking();
                    break;
                case 5:
                    Console.Clear();
                    mainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please input a valid option");
                    bookingMenu();
                    break;
            }
        }


        //1. Add Booking //------------------------------------------------------------//BULLETPROOFED[x]
        public static void addBooking()
        {
            string bookingDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            int customerID, flightID;

            Console.WriteLine("*---- Make a booking ------*");

            bool validCustomerID = false;
            do
            {
                Console.WriteLine("\nPlease input the customer ID:");
                if (int.TryParse(Console.ReadLine(), out customerID) && customerID > 0)
                {
                    validCustomerID = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for customer ID.");
                }

            } while (!validCustomerID);

            var existingCustomer = coord.customerExists(customerID);

            if (existingCustomer != null)
            {
                Console.WriteLine("Customer info:");
                Console.WriteLine(coord.viewCustomer(customerID));
                Console.WriteLine("\n");

                bool validFlightID = false;
                do
                {
                    Console.WriteLine("\nPlease input the flight number:");
                    Console.Write("#");
                    if (int.TryParse(Console.ReadLine(), out flightID) && flightID > 0)
                    {
                        validFlightID = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a valid positive integer for flight ID.");
                    }

                } while (!validFlightID);

                var existingFlight = coord.flightExists(flightID);

                if (existingFlight != null)
                {
                    Console.WriteLine("Flight info:");
                    Console.WriteLine(coord.viewFlight(flightID));

                    if (coord.addBooking(bookingDate, flightID, customerID))
                    {
                        Console.WriteLine("\nBooking added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Cannot add booking, memory is full!");
                    }
                }
                else
                {
                    Console.WriteLine("Flight not found...");
                }
            }
            else
            {
                Console.WriteLine("Customer not found...");
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            bookingMenu();
        }


        //2. View a particular Booking    //------------------------------------------------------------//BULLETPROOFED[x]
        public static void printBooking()
        {
            Console.WriteLine("*---- Booking search ----*");
            int bookingID;

            bool validBookingID = false;

            do
            {
                Console.WriteLine("Please input the Booking ID: ");
                if (int.TryParse(Console.ReadLine(), out bookingID) && bookingID > 0)
                {
                    validBookingID = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for Booking ID.");
                }

            } while (!validBookingID);

            var bookingInfo = coord.viewBooking(bookingID);

            if (bookingInfo != null)
            {
                Console.WriteLine(bookingInfo);
            }
            else
            {
                Console.WriteLine("Booking not found...");
            }

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey(true); // Use true to prevent displaying the pressed key
            bookingMenu();
        }


        //3. View all bookings  //----------------------------------------------------//BULLETPROOFED[x]
        public static void printAllBookings()
        {
            Console.WriteLine(coord.viewAllBookings());

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            bookingMenu();
        }


        public static void deleteBooking() //---------------------------------------//BULLETPROOFED[x]
        {
            int bookingID;

            bool validBookingID = false;

            Console.WriteLine("*DELETE A BOOKING*");

            do
            {
                Console.WriteLine("Please input the Booking ID:");
                if (int.TryParse(Console.ReadLine(), out bookingID) && bookingID > 0)
                {
                    validBookingID = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for Booking ID.");
                }

            } while (!validBookingID);

            var bookingInfo = coord.viewBooking(bookingID);

            if (coord.searchBooking(bookingID) != null)
            {
                Console.WriteLine(bookingInfo);

                Console.WriteLine("\n *Are you sure you want to delete this Booking?* [Y/N]?");
                string input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    Console.WriteLine(coord.deleteBooking(bookingID));
                }
                else
                {
                    Console.WriteLine("Process canceled.");
                }
            }
            else
            {
                Console.WriteLine("Booking not found. Deletion aborted.");
            }

            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey(true); // Use true to prevent displaying the pressed key
            bookingMenu();
        }





        //----------------------------------------------- EXIT ---------------------------// BULLETPROOFED[x]

        static void ExitWithFinesse()
        {
            int millisecondsDelay = 1000;
            Console.WriteLine($"Exiting the program...");
            Thread.Sleep(millisecondsDelay); // Wait for the specified time

            Console.WriteLine("Done!");
            Environment.Exit(0); // 0 indicates a normal program termination
        }



        //---------------------------MAIN METHOD ---------------------------//
        private static void Main(string[] args)
        {
            mainMenu();
        }
    }

}

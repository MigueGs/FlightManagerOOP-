using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class Coordinator
	{
		private FlightManager flights;
		private CustomerManager customers;
		private BookingManager bookings;


		public Coordinator(FlightManager flights, CustomerManager customers, BookingManager bookings)
		{
			this.flights = flights;
			this.customers = customers;
			this.bookings = bookings;
		}

		//--------- FLIGHTS -----------//

		//1. Add a flight
		public bool addFlight(string origin, string destination, int maxSeats) {
			return flights.addFlight(origin, destination, maxSeats);
		}

		//2. View a specific flight
		public string viewFlight( int flightNumber ) {
            string s;
			s = flights.printFlight(flightNumber);
            return s;

		}

		//3. View all flights
		public string viewAllFlights() {
			return flights.printAllFlights();
		}

		//4. Delete a flight
		public string deleteFlight( int flightNumber ) {
			string s;
			int result = flights.deleteFlight(flightNumber);

			if (result == 1)
			{
				s = "Flight deleted sucessfully!";
				return s;
			}
			else if (result == 2)
			{
				s = "Error! a booked flight cannot be deleted!";
				return s;
			}
			else {
				s = "Flight not found...";
				return s;
			}
			
		}

        public string GetAllCustomersInFlight(int flightNumber) {
            return bookings.GetAllCustomersInFlight(flightNumber);
        }

        public Flight flightExists(int flightID) {
            return flights.searchFlight(flightID);
        }

        //-------- CUSTOMERS ----------//

        //1. Add a customer
        public bool addCustomer(string FirstName, string LastName, string PhoneNumber)
        {
			return customers.addCustomer(FirstName, LastName, PhoneNumber);
        }

        //2. View a specific customer
        public string viewCustomer(int customerID)
        {
			return customers.printCustomer(customerID);
        }

        //3. View all customer
        public string viewAllCustomers()
        {
            return customers.printAllCustomers();
        }

        //4. Delete a customer
        public string deleteCustomer(int customerID)
        {
            string s;
            int result = customers.deleteCustomer(customerID);

            if (result == 1)
            {
                s = "Customer deleted sucessfully!";
                return s;
            }
            else if (result == 2)
            {
                s = "Cannot delete customer! it has a booked flight!";
                return s;
            }
            else
            {
                s = "Customer not found...";
                return s;
            }

        }

        //5. Customer exists:
        public Customer customerExists(int customerID) {
            return customers.searchCustomer(customerID);
        }


        //-------- BOOKINGS ----------//

        //1. Add a booking
        public bool addBooking(string bookingDate, int flightID, int customerID)
        {
            Flight flight = flights.searchFlight(flightID);
            Customer customer = customers.searchCustomer(customerID);

            return bookings.addBooking(bookingDate, flight, customer);
        }

        //2. View a specific booking
        public string viewBooking(int bookingID)
        {
            return bookings.printBooking(bookingID);
        }

        //3. View all bookings
        public string viewAllBookings()
        {
            return bookings.printAllBookings();
        }

        //4. Delete a booking
        public string deleteBooking(int bookingID)
        {
            string s;
            bool result = bookings.deleteBooking(bookingID);
            if (result) {
                s = "Booking deleted successfully!";
                return s;
            }
            s = "Booking not found...";
            return s;

        }

        public Booking searchBooking(int bookingNumber) {
            return bookings.searchBooking(bookingNumber);
        }



    }
}


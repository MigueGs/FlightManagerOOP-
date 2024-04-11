using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class BookingManager
	{
        private int numBookings;
        private int maxBookings;
        private Booking[] bookingList;
        private static int seedID;


        public BookingManager(int seed, int maxBookings)
		{
            this.numBookings = 0;
            this.maxBookings = maxBookings;
            this.bookingList = new Booking[maxBookings];
            seedID = seed;

		}

        public bool addBooking(string bookingDate, Flight flight, Customer customer) {
            if (numBookings < maxBookings) {
                if (flight.increaseNumPassengers())
                {

                    bookingList[numBookings] = new Booking(seedID, bookingDate, flight, customer);
                    numBookings++;
                    seedID++;
                    customer.increaseNumberOfBookings();
                    customer.hasBookingTrue();
                    return true;
                }
            }
            return false;
        }

        public string printAllBookings() {
            string s = "------ BOOKING LISTING -------";
            for (int x = 0; x < numBookings; x++) {
                s += "\n" + bookingList[x].ToString();
            }
            return s;
        }


        public Booking searchBooking(int bookingID)
        {
            foreach (var booking in bookingList)
            {
                if (booking != null && booking.getBookingID() == bookingID)
                {
                    return booking;
                }
            }
            return null; // Booking not found
        }

        public string printBooking(int bookingID) {
            string s;
            if (searchBooking(bookingID) != null) {
                s = searchBooking(bookingID).ToString();
                return s;
            }
            s = "Booking not found...";
            return s;
        }


        public bool deleteBooking(int bookingID)
        {

            // Find the index of the booking with the given ID
            int indexToDelete = -1;

            for (int i = 0; i < numBookings; i++)
            {
                if (bookingList[i] != null && bookingList[i].getBookingID() == bookingID)
                {
                    indexToDelete = i;
                    break;
                }
            }

            // Check if the booking exists
            if (indexToDelete != -1)
            {
                // Retrieve the associated flight and customer
                Flight associatedFlight = bookingList[indexToDelete].getFlight();
                Customer associatedCustomer = bookingList[indexToDelete].getCustomer();

                // Remove the booking from the array
                for (int i = indexToDelete; i < numBookings - 1; i++)
                {
                    bookingList[i] = bookingList[i + 1];
                }

                // Clear the last element
                bookingList[numBookings - 1] = null;

                // Update the number of bookings
                numBookings--;

                //THE BOOKING IS DELETED OUT OF BOOKINGLIST

                // Decrease the number of passengers for the associated flight
                associatedFlight.decreaseNumPassengers();

                // Check if the associatedCustomer has other bookings:
                if ((hasOtherBookings(associatedCustomer.getCustomerID()) == false)) {
                    //If customer DOES NOT have more bookings, then turn hasBooking state off:
                    associatedCustomer.hasBookingFalse();
                }

                //Booking deleted successfully
                return true;
            }
            else
            {
                //Booking not found
                return false;
            }
        }

        public bool hasOtherBookings(int customerID)
        {
            foreach (Booking booking in bookingList)
            {
                //if ((booking.getCustomer().getCustomerID()) == customerID)
                if(booking != null && booking.getCustomer() != null && booking.getCustomer().getCustomerID() == customerID)
                {
                    return true;
                }
            }
            return false;

        }

        public string GetAllCustomersInFlight(int flightNumber)
        {
            string s = "";

            foreach (Booking booking in bookingList)
            {
                if (booking != null && booking.getFlight() != null && booking.getFlight().getFlightNumber() == flightNumber)
                {
                    Customer customer = booking.getCustomer();

                    if (customer != null)
                    {
                        s += "\n----Passengers----";
                        s += "\nCustomer ID:    " + customer.getCustomerID();
                        s += "\nFull Name:      " + customer.getFirstName() + " " + customer.getLastName();
                        s += "\nPhone NUmber:   " + customer.getPhoneNumber();
                        s += "\n";

                    }
                }
            }

            return s;
        }

    }
}


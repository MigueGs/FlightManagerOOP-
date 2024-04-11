using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class Booking
	{
		private string bookingDate;
		private int bookingID; //Assigned by the BookingManager class
		private Flight flight;
		private Customer customer;


		public Booking(int bookingID, string bookingDate, Flight flight, Customer customer)
		{
			this.bookingDate = bookingDate;
			this.bookingID = bookingID;
			this.flight = flight;
			this.customer = customer;
		}

        // Getters
        public string getBookingDate()
        {
            return bookingDate;
        }

        public int getBookingID()
        {
            return bookingID;
        }

        public Flight getFlight()
        {
            return flight;
        }

        public Customer getCustomer()
        {
            return customer;
        }


        // Setters
        public void setBookingDate(string bookingDate)
        {
            this.bookingDate = bookingDate;
        }

        public void setFlight(Flight flight)
        {
            this.flight = flight;
        }

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }

        //TS
        public override string ToString()
        {
            string s = "\n*--------------";
            s += "\nBooking Date:       " + bookingDate;
            s += "\nBooking ID:         #" + bookingID;
            s += "\nFlight Number:      #" + flight.getFlightNumber();
            s += "\nCustomer:           " + customer.getFirstName() + " " + customer.getLastName();
            return s;
        }
    }
}


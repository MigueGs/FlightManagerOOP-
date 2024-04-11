using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class Customer
	{
		private int customerID; //Must be assigned by system in the CustomerManager class
		private string fName;
		private string lName;
		private string phoneNum;
        private int numOfBookings; //Pending: handle this in the booking manager
        private bool hasBooking;


		public Customer(int customerID, string FirstName, string LastName, string PhoneNumber, int NumberOFBookings)
		{
			this.customerID = customerID;
			this.fName = FirstName;
			this.lName = LastName;
			this.phoneNum = PhoneNumber;
			this.numOfBookings = NumberOFBookings;
            this.hasBooking = false;

		}

        // Getters
        public int getCustomerID()
        {
            return customerID;
        }

        public string getFirstName()
        {
            return fName;
        }

        public string getLastName()
        {
            return lName;
        }

        public string getPhoneNumber()
        {
            return phoneNum;
        }

        public int getNumberOfBookings()
        {
            return numOfBookings;
        }

        public bool HasBooking() {
            return hasBooking;
        }



        // Setters

        //NO ID SETTER

        public void setFirstName(string firstName)
        {
            this.fName = firstName;
        }

        public void setLastName(string lastName)
        {
            this.lName = lastName;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNum = phoneNumber;
        }

        public void increaseNumberOfBookings()
        {
            this.numOfBookings++;
        }

        public void descreaseNumberOfBookings()
        {
            this.numOfBookings--;
        }

        public void hasBookingTrue() {
            this.hasBooking = true;
        }

        public void hasBookingFalse()
        {
            this.hasBooking = false;
        }


        //TS
        public override string ToString()
        {
            string s = " \n*------------";
            s += "\n Customer ID:       " + customerID;
            s += "\n First Name:        " + fName;
            s += "\n Last Name:         " + lName;
            s += "\n Phone Number:      " + phoneNum;
            s += "\n Total Bookings:    " + numOfBookings;

            return s;
        }
    }
}


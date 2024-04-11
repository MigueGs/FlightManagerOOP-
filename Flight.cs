/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
using System;
namespace OOP_Flight_Manager
{
	public class Flight
	{
		private int flightNumber; //Assigned by the FlighManager
		private string origin;
		private string destination;
		private int maxSeats;
		private int numPassengers;


		public Flight(int flightNumber, string origin, string destination, int maxSeats, int numPassengers)
		{
			this.flightNumber = flightNumber;
			this.origin = origin;
			this.destination = destination;
			this.maxSeats = maxSeats;
			this.numPassengers = numPassengers;

		}
        // Getters
        public int getFlightNumber()
        {
            return flightNumber;
        }

        public string getOrigin()
        {
            return origin;
        }

        public string getDestination()
        {
            return destination;
        }

        public int getMaxSeats()
        {
            return maxSeats;
        }

        public int getNumPassengers()
        {
            return numPassengers;
        }

        // Setters

        

        public void setOrigin(string origin)
        {
            this.origin = origin;
        }

        public void setDestination(string destination)
        {
            this.destination = destination;
        }

        public void setMaxSeats(int maxSeats)
        {
            this.maxSeats = maxSeats;
        }

        public void setNumPassengers(int numPassengers)
        {
            this.numPassengers = numPassengers;
        }


        public bool increaseNumPassengers() {
            if (numPassengers < maxSeats) {
                numPassengers++;
                return true;
            }
            return false;
        }

        public bool decreaseNumPassengers()
        {
            if (numPassengers > 0)
            {
                numPassengers--;
                return true;
            }
            return false;
        }


        //TS
        public override string ToString()
        {
            string s = "\n*-----------";
            s += "\nFlight Number:      #" + flightNumber;
            s += "\nOrigin:             " + origin;
            s += "\nDestination:        " + destination;
            s += "\nNum of Passangers:  " + numPassengers;
            s += "\nMax Seats:          " + maxSeats;

            return s;
        }

    }
}


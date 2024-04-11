using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class FlightManager
	{
        private int numFlights;
        private int maxFlights;
		private Flight[] flightList;
		private static int seedID;


		public FlightManager(int seed, int maxFlights)
		{
			this.numFlights = 0;
			this.maxFlights = maxFlights;
			this.flightList = new Flight[maxFlights];
			seedID = seed;
		}

		public bool addFlight(string origin, string destination, int maxSeats) {
			if (numFlights < maxFlights) {
				flightList[numFlights] = new Flight(seedID, origin, destination, maxSeats, 0);
				seedID++;
				numFlights++;
				return true;
			}
			return false;
		}

		public string printAllFlights() {
			string s = "-------FLIGHT LISTING-------";
			for (int x = 0; x < numFlights; x++) {
				s+= "\n" + flightList[x].ToString();
			}
			return s;
		}

        public Flight searchFlight(int flightNumber)
        {
            foreach (var flight in flightList)
            {
                if (flight != null && flight.getFlightNumber() == flightNumber)
                {
                    return flight;
                }
            }
            return null; // Flight not found
        }

        public string printFlight(int flightNumber) {
            string s;
            if (searchFlight(flightNumber) != null) {
                s = "FLIGHT NUMBER. " + flightNumber;
                s += "\n" + searchFlight(flightNumber).ToString();
                return s;
            }
            s = "Flight not found...";
            return s;
        }



        public int deleteFlight(int flightID)
            //We can make this function return int:
                //1= Flight has been deleted
                //2= Cannot delete Flight (customer has booked it)
                //3= Cannot delete Flight (flight id not found)
        {

            // Find the index of the flight with the given ID
            int indexToDelete = -1;

            for (int i = 0; i < numFlights; i++)
            {
                if (flightList[i].getFlightNumber() == flightID)
                {
                    indexToDelete = i;
                    break;
                }
            }

            // Check if the flight exists
            if (indexToDelete != -1)
            {
                // Check if there are no customers booked for this flight
                if (flightList[indexToDelete].getNumPassengers() == 0)
                {
                    // Shift the remaining flights to fill the gap
                    for (int i = indexToDelete; i < numFlights - 1; i++)
                    {
                        flightList[i] = flightList[i + 1];
                    }

                    // Decrease the number of flights
                    numFlights--;

                    //Flight has been deleted.
                    //return true;
                    return 1;
                }
                else
                {
                    //Cannot delete flight = customer booked flight
                    //return false;
                    return 2;
                }
            }
            else
            {
                //Cannot delete flight, flight not found.
                //return false;
                return 3;
            }
        }




    }
}


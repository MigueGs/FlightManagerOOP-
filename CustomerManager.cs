using System;
/*
 * SAMUEL GALLEGO RIVERA    -  
 * MIGUEL ANGEL GUTIERREZ   -
 * AKOREDE OSUNYOKA         -
 * RYAN LUU                 -
 */
namespace OOP_Flight_Manager
{
	public class CustomerManager
	{
        private int numCustomers;
        private int maxCustomers;
        private Customer[] customerList;
        private static int seedID;

        public CustomerManager(int seed, int maxCustomers)
		{
            this.numCustomers = 0;
            this.maxCustomers = maxCustomers;
            this.customerList = new Customer[maxCustomers];
            seedID = seed;
		}


        public bool addCustomer(string FirstName, string LastName, string PhoneNumber){
            if (numCustomers < maxCustomers) {
                customerList[numCustomers] = new Customer(seedID, FirstName, LastName, PhoneNumber, 0);
                seedID++;
                numCustomers++;
                return true;
            }
            return false;

        }

        public string printAllCustomers() {
            string s = "-------CUSTOMER LISTING-------";
            for (int x = 0; x < numCustomers; x++) {
                s += "\n" + customerList[x].ToString();
            }
            return s;
        }

        public Customer searchCustomer(int customerID)
        {
            foreach (var customer in customerList)
            {
                if (customer != null && customer.getCustomerID() == customerID)
                {
                    return customer;
                }
            }
            return null; // Customer not found
        }

        public string printCustomer(int customerID) {

            string s;
            if (searchCustomer(customerID) != null) {
                s = "\n" + searchCustomer(customerID).ToString();
                return s;
            }
            return null;
            
        }


        public int deleteCustomer(int id)
        {
            //We can make this function return int:
                //1= Customer has been deleted succesfully 
                //2= Cannot delete Customer (It has a booked flight)
                //3= Cannot delete Cusotmer (Customer not found)

            // Find the index of the customer with the given ID
            int indexToDelete = -1;

            for (int i = 0; i < numCustomers; i++)
            {
                if (customerList[i] != null && customerList[i].getCustomerID() == id)
                {
                    indexToDelete = i;
                    break;
                }
            }

            // Check if the customer exists
            if (indexToDelete != -1)
            {
                // Check if the customer has bookings
                if (!customerList[indexToDelete].HasBooking())
                {
                    // Delete the customer and shift the array
                    for (int i = indexToDelete; i < numCustomers - 1; i++)
                    {
                        customerList[i] = customerList[i + 1];
                    }

                    // Clear the last element
                    customerList[numCustomers - 1] = null;

                    // Update the number of customers
                    numCustomers--;

                    //Customer has been deleted
                    return 1;
                }
                else
                {
                    //Cannot delete custumer = it has booked a flight
                    return 2;
                }
            }
            else
            {
                //Cannot delete customer = customer not found
                return 3;
            }
        }



    }
}


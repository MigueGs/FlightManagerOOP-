using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Flight_Manager
{
    internal class fileUtilities
    {
        //string filePath = "C:\Users\migue\OneDrive\Documentos";
        public static void SaveFlights(string filePath, Flight[] flights, int num)
        {
            StreamWriter outputStream = new StreamWriter(filePath);
            outputStream.WriteLine(num);

            for (int x = 0; x < num; x++)
            {
                outputStream.WriteLine($"{flights[x].getFlightNumber()} {flights[x].getOrigin()} {flights[x].getDestination()} {flights[x].getMaxSeats()} {flights[x].getNumPassengers()}");
            }

            outputStream.Close();
        }

        /* public static flight[] loadContacts(string location)
         {
             int num; string line;
             Person[] temp;
             StreamReader inputStream = new StreamReader(location);
             num = Convert.ToInt32(inputStream.ReadLine());
             temp = new Person[num + 100];
             for (int x = 0; x < num; x++)
             {
                 line = inputStream.ReadLine();
                 string[] tokens = line.Split();
                 temp[x] = new Person(tokens[0], tokens[1], tokens[2], Convert.ToInt32(tokens[3]));
             }
             inputStream.Close();
             return temp;
         }
        */
    }
}

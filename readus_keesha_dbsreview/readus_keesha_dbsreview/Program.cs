using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace readus_keesha_dbsreview
{
    class Program
    {

        static void Main(string[] args)
        {
            string cs = @"server=172.16.97.1;userid=dbremoteuser;password=password;database=SampleAPIDatabase; port=8889";

            MySqlConnection conn = null;

            Console.Write("Please enter a city to view weather data: ");
            string searchTerm = Console.ReadLine().ToUpper();
            try
            {
                conn = new MySqlConnection(cs);
                MySqlDataReader reader = null;
                conn.Open();

                string stm = "SELECT * from weather where city = '" + searchTerm + "' limit 100";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                   
                    
                        Console.WriteLine("City: " + reader.GetString(2) + " Temp: " + reader.GetDecimal(4) + " Pressure: " + reader.GetDecimal(5) + " Humidity: " + reader.GetInt32(6));
                    
                }

                if (reader.Read() == false)
                {
                    Console.WriteLine("No Data Available for the selected city");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(": {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
            Console.Clear();
            
            //I commented this code out because I did not want the insert statement to run again
            /* 
            conn = null;

            
           
            try
            {
                conn = new MySqlConnection(cs);
                MySqlDataReader reader = null;
                conn.Open();

               
               string stm = "SELECT * from weather ORDER BY createdDate DESC limit 1";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("City: " + reader.GetString(2)+ " Temp: " + reader.GetDecimal(4) + " Pressure: " + reader.GetDecimal(5) + " Humidity: " + reader.GetInt32(6));
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("No Data Available for the selected city: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Below is the last entry for the weather table ");

            try
            {
                conn = new MySqlConnection(cs);
                MySqlDataReader reader = null;
                conn.Open();


                string stm = "INSERT INTO weather (city, temp, pressure, humidity) value ('Orlando', 62, 30.27, 77)";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("City: " + reader.GetString(2) + " Temp: " + reader.GetDecimal(4) + " Pressure: " + reader.GetDecimal(5) + " Humidity: " + reader.GetInt32(6));
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("No Data Available for the selected city: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
            */
        }
    }
    
}


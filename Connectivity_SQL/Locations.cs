using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity_SQL
{
    public class Locations
    {
        // Membuat Tabel Location
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        //GETALL 
        public List<Locations> GetAllLocations()
        {
            List<Locations> locations = new List<Locations>();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_locations";

                //Membuat koneksi    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Locations();
                        loc.Id = reader.GetInt32(0);
                        loc.StreetAddress = reader.GetString(1);
                        loc.PostalCode = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.StateProvince = reader.GetString(4);
                        loc.CountryId = reader.GetString(5);

                        locations.Add(loc);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.connection.Close();
            return locations;
        }

        
        // VIEW MENU LOCATION
        public void ViewMenuLocation()
        {
            // GETALL LOCATION
            Console.Clear();
            Console.WriteLine("\tGET ALL LOCATION\t");
            Console.WriteLine("===================================");
            List<Locations> loc = GetAllLocations();
            foreach (Locations locations in loc)
            {
                Console.WriteLine($"Id: {locations.Id} StreetAddress: {locations.StreetAddress} PostalCode: {locations.PostalCode} City: {locations.City} StateProvince: {locations.StateProvince} CountryId: {locations.CountryId}");
            }
            Console.ReadKey();
        }
    }
}

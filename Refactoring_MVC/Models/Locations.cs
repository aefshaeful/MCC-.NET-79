﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Contexts;
using System.Data;

namespace Refactoring_MVC.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        //GETALL 
        public List<Locations> GetAll()
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
    }
}

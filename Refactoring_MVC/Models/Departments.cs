using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Contexts;

namespace Refactoring_MVC.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }


        // GETALL (SELECT)
        public List<Departments> GetAll()
        {
            var departments = new List<Departments>();
            //List<Regions> region = new List<Regions>();
            try
            {

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_departments";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var depart = new Departments();
                        depart.Id = reader.GetInt32(0);
                        depart.Name = reader.GetString(1);
                        depart.LocationId = reader.GetInt32(2);
                        depart.ManagerId = reader.GetInt32(3);

                        departments.Add(depart);
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
            return departments;
        }
    }
}

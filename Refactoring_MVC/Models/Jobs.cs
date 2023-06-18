using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Contexts;

namespace Refactoring_MVC.Models
{
    public class Jobs
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }


        // GETALL (SELECT)
        public List<Jobs> GetAll()
        {
            var jobs = new List<Jobs>();
            //List<Regions> region = new List<Regions>();
            try
            {

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_jobs";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var jb = new Jobs();
                        jb.Id = reader.GetString(0);
                        jb.Title = reader.GetString(1);
                        jb.MinSalary = reader.GetInt32(2);
                        jb.MaxSalary = reader.GetInt32(3);

                        jobs.Add(jb);
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
            return jobs;
        }
    }
}

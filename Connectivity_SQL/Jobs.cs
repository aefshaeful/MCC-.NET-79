using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity_SQL
{
    public class Jobs
    {
        // MEMBUAT TABLE JOBS
        public string Id { get; set; }
        public string? Title { get; set; }
        public int Min_Salary { get; set; }
        public int Max_Salary { get; set; }


        // GETALL (SELECT)
        public static List<Jobs> GetAllJobs()
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
                        jb.Min_Salary = reader.GetInt32(2);
                        jb.Max_Salary = reader.GetInt32(3);

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

        // VIEW MENU JOBS
        public void ViewMenuJobs()
        {
            //GETALL : JOBS
            Console.Clear();
            Console.WriteLine("\tGET ALL JOBS\t");
            Console.WriteLine("===================================");
            List<Jobs> jobb = GetAllJobs();
            foreach (Jobs jobs in jobb)
            {
                Console.WriteLine($"Id: {jobs.Id}, Title: {jobs.Title}, Min_Salary: {jobs.Min_Salary}, Max_Salary: {jobs.Max_Salary}");
            }
            Console.ReadKey();
        }
    }
}

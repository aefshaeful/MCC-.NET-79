using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Contexts;

namespace Refactoring_MVC.Models
{
    public class Histories
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }


        // GETALL (SELECT)
        public List<Histories> GetAll()
        {
            var histories = new List<Histories>();
            //List<Regions> region = new List<Regions>();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_tr_histories";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var his = new Histories();
                        his.StartDate = reader.GetDateTime(0);
                        his.EmployeeId = reader.GetInt32(1);
                        his.EndDate = reader.GetDateTime(2);
                        his.DepartmentId = reader.GetInt32(3);
                        his.JobId = reader.GetString(4);

                        histories.Add(his);
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
            return histories;
        }
    }
}

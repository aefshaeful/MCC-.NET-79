using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Contexts;

namespace Refactoring_MVC.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirshName { get; set; } /*= string.Empty;*/
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } /*= string.Empty;*/
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal? CommisionPct { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; } 
        public int DepartmentId { get; set; }


        // GETALL (SELECT)
        public List<Employees> GetAll()
        {
            var employees = new List<Employees>();
            //List<Regions> region = new List<Regions>();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_employees";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employees();
                        emp.Id = reader.GetInt32(0);
                        emp.FirshName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.CommisionPct = null;  // Atur sebagai null jika nilainya null
                        emp.ManagerId = reader.GetInt32(8);
                        emp.JobId = reader.GetString(9);
                        emp.DepartmentId = reader.GetInt32(10);

                        employees.Add(emp);
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
            return employees;
        }
    }
}

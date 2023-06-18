using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity_SQL
{
    public class Employees
    {
        // MEMBUAT TABLE Employees
        public int Id { get; set; }
        public string Firsh_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;
        public DateTime Hire_Date { get; set; }
        public int Salary { get; set; }
        public decimal? Commision_Pct { get; set; }
        public int Manager_Id { get; set; }
        public string Job_Id { get; set; } = string.Empty;
        public int Department_Id { get; set; }


        // GETALL (SELECT)
        public List<Employees> GetAllEmployees()
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
                        emp.Firsh_Name = reader.GetString(1);
                        emp.Last_Name = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.Phone_Number = reader.GetString(4);
                        emp.Hire_Date = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.Commision_Pct = null;  // Atur sebagai null jika nilainya null
                        emp.Manager_Id = reader.GetInt32(8);
                        emp.Job_Id = reader.GetString(9);
                        emp.Department_Id = reader.GetInt32(10);

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

        // VIEW MENU EMPLOYEES
        public void ViewMenuEmployees()
        {
            //GETALL : EMPLOYEES
            Console.Clear();
            Console.WriteLine("\tGET ALL EMPLOYEES\t");
            Console.WriteLine("===================================");
            List<Employees> employ = GetAllEmployees();
            foreach (Employees employees in employ)
            {
                Console.WriteLine($"Id: {employees.Id} Firsh_Name: {employees.Firsh_Name} Last_Name: {employees.Last_Name} Email: {employees.Email} Phone_Number: {employees.Phone_Number} Hire_Date: {employees.Hire_Date} Salary: {employees.Salary} Commision_Pct: {employees.Commision_Pct} Manager_Id: {employees.Manager_Id} Job_Id: {employees.Job_Id} Department_Id: {employees.Department_Id}");
            }
            Console.ReadKey();
        }
    }
}

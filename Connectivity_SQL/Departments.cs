using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity_SQL
{
    public class Departments
    {
        // MEMBUAT TABLE DEPARTMENTS
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Location_Id { get; set; }
        public int Manager_Id { get; set; }


        // GETALL (SELECT)
        public List<Departments> GetAllDepartments()
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
                        depart.Location_Id = reader.GetInt32(2);
                        depart.Manager_Id = reader.GetInt32(3);

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

        // VIEW MENU DEPARTMENTS
        public void ViewMenuDepartments()
        {
            //GETALL : DEPARTMENTS
            ViewMenu viewMenu = new ViewMenu();
            Console.Clear();
            Console.WriteLine("\tGET ALL DEPARTMENTS");
            Console.WriteLine("===================================");
            List<Departments> dp = GetAllDepartments();
            foreach (Departments departments in dp)
            {
                Console.WriteLine($"Id: {departments.Id} Name: {departments.Name} Location_Id: {departments.Location_Id} Manager_Id: {departments.Manager_Id}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

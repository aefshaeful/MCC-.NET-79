using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Connectivity_SQLQuery;

namespace Connectivity_SQL
{
    public class ViewMenu
    {
        /*SqlConnection connec = new SqlConnection();*/
       /* connection = Connection.connection;*/
        Regions _region = new Regions();
        Countries _countrie = new Countries();
        Locations _location = new Locations();
        Departments _department = new Departments();
        Employees _employee = new Employees();
        Histories _historie = new Histories();
        Jobs _job = new Jobs();
        LINQ _linq = new LINQ();

        public void View()
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\tWelcome to MyEmployees Database\t");
            Console.WriteLine("============================================");
            Console.WriteLine("1. Data Regions");
            Console.WriteLine("2. Data Countries");
            Console.WriteLine("3. Data Locations");
            Console.WriteLine("4. Data Departments");
            Console.WriteLine("5. Data Employees");
            Console.WriteLine("6. Data Hitories");
            Console.WriteLine("7. Data Jobs");
            Console.WriteLine("8. LINQ");
            Console.WriteLine("9. Exit");
            Console.WriteLine("Please choose a data :");
            int inputView = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (inputView)
                {
                    case 1:
                        _region.ViewMenuRegions();
                        break;
                    case 2:
                        _countrie.ViewMenuCountries();
                        break;
                    case 3:
                        _location.ViewMenuLocation();
                        break;
                    case 4:
                        _department.ViewMenuDepartments();
                        break;
                    case 5:
                        _employee.ViewMenuEmployees();
                        break;
                    case 6:
                        _historie.ViewMenuHistories();
                        break;
                    case 7:
                        _job.ViewMenuJobs();
                        break;
                    case 8:
                        _linq.ViewMenuLinq();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.View();
            }
        }

    }
}

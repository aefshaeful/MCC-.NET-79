using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Controllers
{
    public class LINQController
    {
        /*private LINQ _linq = new LINQ();
        private LINQView _linqview = new LINQView();

        public void ViewMenuLinq()
        {
            ViewMenuController viewMenu = new ViewMenuController();


            //var linq = _linq.GetTakeEmployees();
            //var lin = _linq.GetTolalEmployeesSetDepart();
            //var linq = _linq.MenuLinq();
            //_linqview.MenuLinq(linq);
            //_linqview.GetTakeEmployees(linq);

            Console.WriteLine("\n");
            Console.WriteLine("\tVIEW MENU LINQ\t");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Get Employees With Just Five ID");
            Console.WriteLine("2. Total Employees of Each Department");
            Console.WriteLine("3. Exit");
            Console.Write("Please choose a menu linq :");
            int inputLinq = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (inputLinq)
                {
                    case 1:
                        GetTakeEmployees();
                        break;
                    case 2:
                        GetTolalEmployeesSetDepart();
                        break;
                    case 3:
                        viewMenu.View();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.ViewMenuLinq();
            }
        }*/
    }
}

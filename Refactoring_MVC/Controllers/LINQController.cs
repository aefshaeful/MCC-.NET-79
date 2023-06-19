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
        private LINQView _linqview = new LINQView;

        public void ViewMenuLinq()
        {
            ViewMenuController viewMenu = new ViewMenuController();


            //var linq = _linq.GetTakeEmployees();
            //var lin = _linq.GetTolalEmployeesSetDepart();
            var linq = _linq.MenuLinq();
            _linqview.MenuLinq(linq);
            _linqview.GetTakeEmployees(linq);

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

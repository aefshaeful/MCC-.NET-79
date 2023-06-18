using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Controllers
{
    public class EmployeesController
    {
        private Employees _employees = new Employees();
        private EmployeesView _employeesview = new EmployeesView();

        public void ViewMenuEmployees()
        {
            //GETALL : EMPLOYEES
            var employees = _employees.GetAll();
            _employeesview.GetAll(employees);
        }
    }
}

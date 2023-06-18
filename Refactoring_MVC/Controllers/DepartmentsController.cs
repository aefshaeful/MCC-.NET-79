using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;


namespace Refactoring_MVC.Controllers
{
    public class DepartmentsController
    {
        private Departments _departments = new Departments();
        private DepartmentsView _departmentsview = new DepartmentsView();

        public void ViewMenuDepartments()
        {
            //GETALL : DEPARTMENTS
            var departments = _departments.GetAll();
            _departmentsview.GetAll(departments);
        }

    }
}

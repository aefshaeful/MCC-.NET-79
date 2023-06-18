using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Controllers;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class DepartmentsView
    {
        public void GetAll(List<Departments> departments)
        {
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL DEPARTMENTS");
            Console.WriteLine("===================================");
            
            foreach (Departments depart in departments)
            {
                Console.WriteLine($"Id: {depart.Id} Name: {depart.Name} Location Id: {depart.LocationId} Manager Id: {depart.ManagerId}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

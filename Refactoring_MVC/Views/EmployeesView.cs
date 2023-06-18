using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Controllers;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class EmployeesView
    {
        public void GetAll(List<Employees> employees)
        {
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL EMPLOYEES\t");
            Console.WriteLine("===================================");
            
            foreach (Employees employ in employees)
            {
                Console.WriteLine($"Id: {employ.Id} Firsh Name: {employ.FirshName} Last Name: {employ.LastName} Email: {employ.Email} Phone Number: {employ.PhoneNumber} Hire Date: {employ.HireDate} Salary: {employ.Salary} Commision Pct: {employ.CommisionPct} Manager Id: {employ.ManagerId} Job Id: {employ.JobId} Department Id: {employ.DepartmentId}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

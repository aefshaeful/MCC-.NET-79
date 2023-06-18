using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Controllers;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class HitroriesView
    {
        public void GetAll(List<Histories> histories)
        {
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL HISTORIES\t");
            Console.WriteLine("===================================");
            
            foreach (Histories histori in histories)
            {
                Console.WriteLine($"Start Date: {histori.StartDate} Employee Id: {histori.EmployeeId} EndDate: {histori.EndDate} Department Id: {histori.DepartmentId} Job Id; {histori.JobId}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Controllers;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class JobsView
    {
        public void GetAll(List<Jobs> jobs)
        {
            //GETALL : JOBS
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL JOBS\t");
            Console.WriteLine("===================================");
            
            foreach (Jobs job in jobs)
            {
                Console.WriteLine($"Id: {job.Id}, Title: {job.Title}, Min Salary: {job.MinSalary}, Max Salary: {job.MaxSalary}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_MVC.Models
{
    public class LINQ
    {
        /*Employees employees = new Employees();
        Departments departments = new Departments();
        Locations locations = new Locations();
        Countries countries = new Countries();
        Regions regions = new Regions();

        public list GetTakeEmployees()
        {
            *//*var employees = new Employees();
            var departments = new Departments();
            var locations = new Locations();
            var countries = new Countries();
            var regions = new Regions();*//*

            var employee = (from e in employees.GetAll()
                            join d in departments.GetAll() on e.DepartmentId equals d.Id
                            join l in locations.GetAll() on d.LocationId equals l.Id
                            join c in countries.GetAll() on l.CountryId equals c.Id
                            join r in regions.GetAll() on c.RegionId equals r.Id
                            select new
                            {
                                id = e.Id,
                                FullName = $"{e.FirshName} {e.LastName}",
                                Email = e.Email,
                                PhoneNumber = e.PhoneNumber,
                                Salary = e.Salary,
                                DepartmentsName = d.Name,
                                StreetAddress = l.StreetAddress,
                                CountryName = c.Name,
                                Regions = r.Name
                            }).Take(5);

            foreach (var emp in employee)
            {
                Console.WriteLine("ID :" + emp.id);
                Console.WriteLine("Full Name :" + emp.FullName);
                Console.WriteLine("Email :" + emp.Email);
                Console.WriteLine("Phone Number :" + emp.PhoneNumber);
                Console.WriteLine("Salary :" + emp.Salary);
                Console.WriteLine("Departments Name :" + emp.DepartmentsName);
                Console.WriteLine("Street Address :" + emp.StreetAddress);
                Console.WriteLine("Country Name :" + emp.CountryName);
                Console.WriteLine("Regions :" + emp.Regions);
                Console.WriteLine("======================================");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            this.ViewMenuLinq();
        }

        public void GetTolalEmployeesSetDepart()
        {
            *//*var employees = new Employees();
            var departments = new Departments();*//*

            var employ = (from e in employees.GetAll()
                          join d in departments.GetAll() on e.DepartmentId equals d.Id
                          group e by d.Name into g
                          where g.Count() > 0
                          select new
                          {
                              DepartmentsName = g.Key,
                              TotalEmployees = g.Count(),
                              MinSalary = g.Min(e => e.Salary),
                              MaxSalary = g.Max(e => e.Salary),
                              AverageSalary = g.Average(e => e.Salary)
                          });

            foreach (var em in employ)
            {
                Console.WriteLine("Department Name :" + em.DepartmentsName);
                Console.WriteLine("Total Employees :" + em.TotalEmployees);
                Console.WriteLine("Min Salary :" + em.MinSalary);
                Console.WriteLine("Max Salary :" + em.MaxSalary);
                Console.WriteLine("Average Salary :" + em.AverageSalary);
                Console.WriteLine("======================================");
                Console.WriteLine(" ");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            this.ViewMenuLinq();
        }*/
    }
}

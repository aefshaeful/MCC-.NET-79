using Connectivity_SQLQuery;

namespace Connectivity_SQL
{
    public class LINQ
    {
        public void GetTakeEmployees()
        {
            var employees = new Employees();
            var departments = new Departments();
            var locations = new Locations();
            var countries = new Countries();
            var regions = new Regions();

            var employee = (from e in employees.GetAllEmployees()
                            join d in departments.GetAllDepartments() on e.Department_Id equals d.Id
                            join l in locations.GetAllLocations() on d.Location_Id equals l.Id
                            join c in countries.GetAllCountries() on l.CountryId equals c.Id
                            join r in regions.GetAllRegion() on c.RegionId equals r.Id
                            select new
                            {
                                id = e.Id,
                                FullName = $"{e.Firsh_Name} {e.Last_Name}",
                                Email = e.Email,
                                PhoneNumber = e.Phone_Number,
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
        }

        public void GetTolalEmployeesSetDepart()
        {
            var employees = new Employees();
            var departments = new Departments();

            var employ = (from e in employees.GetAllEmployees()
                          join d in departments.GetAllDepartments() on e.Department_Id equals d.Id
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
        }

    }
}

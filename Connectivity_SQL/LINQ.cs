using Connectivity_SQLQuery;

namespace Connectivity_SQL
{
    public class LINQ
    {
        public void Main()
        {
            var employees = new Employees();
            var departments = new Departments();
            var locations = new Locations();
            var countries = new Countries();
            var regions = new Regions();

            var employee = from e in employees.GetAllEmployees()
                            join d in departments.GetAllDepartments() on e.Department_Id equals d.Id
                            join l in locations.GetAllLocations() on d.Location_Id equals l.Id
                            join c in countries.GetAllCountries() on l.CountryId equals c.Id
                            join r in regions.GetAllRegion() on c.RegionId equals r.Id
                            select new
                            {
                                id = e.Id,
                                FirstName = e.Firsh_Name,
                                LastName = e.Last_Name,
                                Email = e.Email,
                                PhoneNumber = e.Phone_Number,
                                Salary = e.Salary,
                                DepartmentsName = d.Name,
                                StreetAddress = l.StreetAddress,
                                CountryName = c.Name,
                                Regions = r.Name,

                            };

            foreach (var emp in employee)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Email} {emp.PhoneNumber} {emp.Salary} {emp.DepartmentsName} {emp.StreetAddress} {emp.CountryName} {emp.Regions}");
            }
        }
    }
}


/*Buatlah** Method LINQ** untuk menampilkan data dengan kriteria yang ditampilkan
1. Data employee
2. Tambahkan informasi nama department
3. Tambahkan informasi lokasi
4. Tambahkan informasi country
5. Tambahkan informasi region
6. Limit data yang tampil hanya 5
column yang tampil : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name.*/
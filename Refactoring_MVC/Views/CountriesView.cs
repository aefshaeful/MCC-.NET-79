using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class CountriesView
    {
        public void GetById(Countries country)
        {
            Console.WriteLine($"Id: {country.Id} Name: {country.Name} RegionId: {country.RegionId}");
        }

        public void GetAll(List<Countries> countries)
        {
            foreach (Countries country in countries)
            {
                GetById(country);
            }
        }

        public void NotFound()
        {
            Console.WriteLine("Data Not Found!");
        }
    }
}

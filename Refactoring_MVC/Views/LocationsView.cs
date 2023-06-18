using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Controllers;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class LocationsView
    {
        public void GetAll(List<Locations> locations)
        {
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL LOCATION\t");
            Console.WriteLine("===================================");

            foreach (Locations location in locations)
            {
                Console.WriteLine($"Id: {location.Id} StreetAddress: {location.StreetAddress} PostalCode: {location.PostalCode} City: {location.City} StateProvince: {location.StateProvince} CountryId: {location.CountryId}");
            }
            Console.ReadKey();
            viewMenu.View();
        }
    }
}

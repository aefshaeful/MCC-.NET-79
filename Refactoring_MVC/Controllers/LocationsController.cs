using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Controllers
{
    public class LocationsController
    {
        private Locations _locations = new Locations();
        private LocationsView _locationsview = new LocationsView();

        // VIEW MENU LOCATION
        public void ViewMenuLocation()
        {
            // GETALL LOCATION
           /* ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL LOCATION\t");
            Console.WriteLine("===================================");*/
            
            var locations = _locations.GetAll();
            _locationsview.GetAll(locations);

            /*Console.ReadKey();
            viewMenu.View();*/
        }
    }
}

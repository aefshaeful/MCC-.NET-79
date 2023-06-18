using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Views
{
    public class RegionsView
    {
        public void GetById(Regions regions)
        {
            Console.WriteLine($"Id: {region.Id} Name: {region.Name}");
            /*Console.ReadKey();*/
        }
    }
}

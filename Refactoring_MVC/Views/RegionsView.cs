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
        public void GetById(Regions region)
        {
            Console.WriteLine($"Id: {region.Id} Name: {region.Name}");
        }

        public void GetAll(List<Regions> regions)
        {
            foreach (Regions region in regions)
            {
                GetById(region);
            }
        }

        public void NotFound()
        {
            Console.WriteLine("Data Not Found!");
        }
    }
}

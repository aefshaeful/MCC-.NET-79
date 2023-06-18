using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Views;
using Connection.Models;
using Refactoring_MVC.Views;

namespace Refactoring_MVC.Controllers
{
    public class RegionsController
    {
        private Regions _regions = new Regions();  // Models
        private RegionsView _regionsView = new RegionsView();


        // VIEW MENU INSERT : REGIONS
        public void ViewMenuInsert()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tINSERT TO TABLE\t");
            Console.WriteLine("===================================");
            Console.Write("Add a new regions name :");
            string name = Console.ReadLine();
            int isInsertSuccessful = Regions.insertRegion(name);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }
            Console.ReadKey();
            /*ViewMenuRegions();*/
        }


        // VIEW MENU GETBY ID : REGIONS
        public void ViewMenuGetById()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tGET REGIONS BY ID\t");
            Console.WriteLine("===================================");
            Console.Write("Input region id :");
            int id = int.Parse(Console.ReadLine());

            var region = _regions.GetById(id);

            if (region == null)
            {
                _regionsView.NotFound();
            }
            else
            {
                _regionsView.GetById(region);
            }
            Console.ReadKey();
        }


        // VIEW MENU UPDATE : REGIONS
        public void ViewMenuUpdate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tUPDATE TABLE REGIONS\t");
            Console.WriteLine("===================================");
            Console.Write("Input region id :");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Add the name regions to be update :");
            string newname = Console.ReadLine();
            int isUpdateSuccessful = Regions.UpdateRegionsName(id, newname);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
            Console.ReadKey();
            /* ViewMenuRegions();*/
        }


        // VIEW MENU DELETE : REGIONS
        public void ViewMenuDelete()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tDELETE TABLE REGIONS\t ==");
            Console.WriteLine("===================================");
            Console.Write("Input a region id to delete :");
            int id = int.Parse(Console.ReadLine());
            int isDeleteSuccessful = Regions.DeleteRegionsName(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
            Console.ReadKey();
            /*ViewMenuRegions();*/
        }

        // VIEW MENU GETALL : REGIONS
        public void ViewMenuRegions()
        {
            bool isFinish = true;
            do
            {
                ViewMenuController viewMenu = new ViewMenuController();
                Console.Clear();
                Console.WriteLine("\tGET ALL REGIONS\t");
                Console.WriteLine("===================================");

               /* List<Regions> regions = _regions.GetAll();
                foreach (Regions region in regions)
                {
                    Console.WriteLine($"id: {region.Id} Name: {region.Name}");
                }*/

                var regions = _regions.GetAll();
                _regionsView.GetAll(regions);

                Console.WriteLine("\n");
                Console.WriteLine("\tVIEW MENU REGIONS\t");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Insert Table");
                Console.WriteLine("2. Getby Id");
                Console.WriteLine("3. Update Table");
                Console.WriteLine("4. Delete Table");
                Console.WriteLine("5. Exit");
                Console.Write("Select a menu :");

                try
                {
                    int inputMenuReg = Convert.ToInt32(Console.ReadLine());
                    switch (inputMenuReg)
                    {
                        case 1:
                            ViewMenuInsert();
                            ViewMenuRegions();
                            break;
                        case 2:
                            ViewMenuGetById();
                            ViewMenuRegions();
                            break;
                        case 3:
                            ViewMenuUpdate();
                            ViewMenuRegions();
                            break;
                        case 4:
                            ViewMenuDelete();
                            ViewMenuRegions();
                            break;
                        case 5:
                            viewMenu.View();
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again...");
                            Console.ReadLine();
                            ViewMenuRegions();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    this.ViewMenuRegions();
                }
            }
            while (isFinish);
        }
    }
}

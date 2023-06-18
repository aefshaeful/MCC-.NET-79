using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;


namespace Refactoring_MVC.Controllers
{
    public class CountriesController
    {
        private Countries _countries = new Countries();  // Models
        private CountriesView _countriesView = new CountriesView();

        // VIEW MENU INSERT : COUNTRIES
        public void ViewMenuInsert()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tINSERT TO TABLE\t");
            Console.WriteLine("===================================");
            Console.Write("Add a new countries id :");
            string id = Console.ReadLine();
            Console.Write("Add a new name countries :");
            string name = Console.ReadLine();
            Console.Write("Input region id :");
            int region_id = int.Parse(Console.ReadLine());
            int isInsertSuccessful = _countries.insert(id, name, region_id);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }
            Console.ReadKey();
        }

        // VIEW MENU GETBY ID : COUNTRIES
        public void ViewMenuGetById()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tGet Countries by ID\t");
            Console.WriteLine("===================================");
            Console.Write("Input countries id :");
            string id = Console.ReadLine();

            var count = _countries.GetById(id);
            if (count == null)
            {
                _countriesView.NotFound();
            }
            else
            {
                _countriesView.GetById(count);
            }
            Console.ReadKey();
        }

        // VIEW MENU UPDATE
        public void ViewMenuUpdate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tUPDATE TABLE COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.Write("Input countries id :");
            string id = Console.ReadLine();
            Console.Write("Add new country name to update :");
            string newname = Console.ReadLine();
            Console.Write("Input region id: ");
            int region_id = int.Parse(Console.ReadLine());
            int isUpdateSuccessful = _countries.Update(id, newname, region_id);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
            Console.ReadKey();
        }

        // VIEW MENU DELETE : COUNTRIES
        public void ViewMenuDelete()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tDELETE TABLE COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.Write("Input a countries id to delete  :");
            string id = Console.ReadLine();
            int isDeleteSuccessful = _countries.Delete(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
            Console.ReadKey();
        }

        // VIEW MENU GETALL : COUNTRIES
        public void ViewMenuCountries()
        {
            //GETALL : COUNTRIES
            ViewMenuController viewMenu = new ViewMenuController();
            Console.Clear();
            Console.WriteLine("\tGET ALL COUNTRIES\t");
            Console.WriteLine("===================================");
            
            var countries = _countries.GetAll();
            _countriesView.GetAll(countries);
           

            Console.WriteLine("\n");
            Console.WriteLine("\tVIEW MENU COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Insert Table");
            Console.WriteLine("2. Getby Id");
            Console.WriteLine("3. Update Table");
            Console.WriteLine("4. Delete Table");
            Console.WriteLine("5. Exit");
            Console.Write("Select a menu :");

            try
            {
                int inputMenuCount = Convert.ToInt32(Console.ReadLine());
                switch (inputMenuCount)
                {
                    case 1:
                        ViewMenuInsert();
                        ViewMenuCountries();
                        break;
                    case 2:
                        ViewMenuGetById();
                        ViewMenuCountries();
                        break;
                    case 3:
                        ViewMenuUpdate();
                        ViewMenuCountries();
                        break;
                    case 4:
                        ViewMenuDelete();
                        ViewMenuCountries();
                        break;
                    case 5:
                        viewMenu.View();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again...");
                        Console.ReadLine();
                        ViewMenuCountries();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.ViewMenuCountries();
            }
        }

    }
}

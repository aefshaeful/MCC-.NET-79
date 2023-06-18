using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Controllers
{
    public class HistoriesController
    {
        private Histories _histories = new Histories();
        private HitroriesView _historiesview = new HitroriesView();

        public void ViewMenuHistories()
        {
            //GETALL : HISTORIES
            var histories = _histories.GetAll();
            _historiesview.GetAll(histories);
        }
    }
}

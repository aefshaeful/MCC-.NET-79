using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_MVC.Views;
using Refactoring_MVC.Models;

namespace Refactoring_MVC.Controllers
{
    public class JobsController
    {
        private Jobs _jobs = new Jobs();
        private JobsView _jobsview = new JobsView();

        public void ViewMenuJobs()
        {
            var jobs = _jobs.GetAll();
            _jobsview.GetAll(jobs);
        }
    }
}

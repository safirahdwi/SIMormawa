using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ormawa.BusinessModel;
using Ormawa.ViewModels;

namespace Ormawa.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly PublikasiRepo repo;
        DashboardViewModel vmod = new DashboardViewModel();
        public DashboardsController(PublikasiRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            vmod.ListPublikasi = repo.GetPublikasiListDashboard();
            return View(vmod);
        }
   
        public IActionResult Dashboard1()
        {
            return View();
        }

        public IActionResult Dashboard2()
        {
            return View();
        }

    

    }
}
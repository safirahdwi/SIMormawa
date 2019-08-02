using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.JQuery.DataTables;
using Ormawa.Models;
using Ormawa.ViewModels;
using Ormawa.BusinessModel;

namespace Ormawa.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;
        private readonly OrganisasiOrmawaRepo _repo;

        public DefaultController(DBINTEGRASI_MASTER_BAYUPPKU2Context db, OrganisasiOrmawaRepo repo)
        {
            _db = db;
            _repo = repo;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("DataTablesExample", "Default");
        }
       
        [Authorize]
        public IActionResult DataTablesExample()
        {
            OrganisasiOrmawaVM vmod = new OrganisasiOrmawaVM(); 
            var dataProviderUrl = Url.Action("DataTablesExampleDataProvider");
            var viewModel = DataTablesHelper.DataTableVm<OrganisasiOrmawaRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        [Authorize]
        public DataTablesResult<OrganisasiOrmawaRow> DataTablesExampleDataProvider(DataTablesParam param)
        {
            var query = _repo.GetOrganisasiList();

            var no = param.iDisplayStart + 1;

            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                Aksi = $"<input type=\"button\" class=\"btn btn-default\" value=\"Aksi\" onclick=\"alert('Orang ID: {row.Id}')\">"
            });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

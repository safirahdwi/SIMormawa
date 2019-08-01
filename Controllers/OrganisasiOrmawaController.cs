using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.JQuery.DataTables;
using Ormawa.ViewModels;
using Ormawa.BusinessModel;

namespace Ormawa.Controllers
{
    public class OrganisasiOrmawaController : Controller
    {
        private readonly OrganisasiOrmawaRepo _repo;
        OrganisasiOrmawaVM vmod = new OrganisasiOrmawaVM();
        public OrganisasiOrmawaController(OrganisasiOrmawaRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<OrganisasiOrmawaRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        public DataTablesResult<OrganisasiOrmawaRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetOrganisasiList();

            var no = param.iDisplayStart + 1;

            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                Aksi = Buttonstring(row.Id)
            });
        }

        public string Buttonstring(int ID)
        {
            var res = "<div class='btn-group'>"
                         + "<a href='/OrganisasiOrmawa/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/OrganisasiOrmawa/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/OrganisasiOrmawa/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }

        public IActionResult Detail(int id)
        {
            vmod = _repo.GetOrganisasiDetails(id);
            return View(vmod);
        }
    }
}
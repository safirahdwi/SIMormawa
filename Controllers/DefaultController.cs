using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.JQuery.DataTables;
using Ormawa.Models;
using Ormawa.ViewModels;

namespace Ormawa.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DBINTEGRASI_MASTERContext _db;

        public DefaultController(DBINTEGRASI_MASTERContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("DataTablesExample", "Default");
        }

        [Authorize]
        public IActionResult DataTablesExample()
        {
            var dataProviderUrl = Url.Action("DataTablesExampleDataProvider");
            var viewModel = DataTablesHelper.DataTableVm<DataTablesExampleRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;
            
            return View(viewModel);
        }
        
        [Authorize]
        public DataTablesResult<DataTablesExampleRow> DataTablesExampleDataProvider(DataTablesParam param)
        {
            var query = _db.Orang.Where(x => !string.IsNullOrWhiteSpace(x.Nama) && x.TanggalLahir != null).OrderBy(x => x.Nama).Select(x => new DataTablesExampleRow
            {
                Id = x.Id,
                Nama = x.Nama,
                TempatLahir = x.TempatLahir,
                TanggalLahir = x.TanggalLahir,
            });

            var no = param.iDisplayStart + 1;

            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                No = no++,
                TanggalLahir = row.TanggalLahir.ToString("D"),
                Aksi = $"<input type=\"button\" class=\"btn btn-default\" value=\"Aksi\" onclick=\"alert('Orang ID: {row.Id}')\">"
            });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

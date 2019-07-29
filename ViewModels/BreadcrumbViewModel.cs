using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class BreadcrumbViewModel
    {
        public string UrlAction { get; set; }
        public string Nama { get; set; }
        public BreadcrumbViewModel() { }
        public BreadcrumbViewModel(string urlAction, string nama) {
            this.UrlAction = urlAction;
            this.Nama = nama;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class Select2ViewModel
    {
        public string id { get; set; }
        public String text { get; set; }

        public Select2ViewModel()
        {
        }
        public Select2ViewModel(string id, string text)
        {
            this.id = id;
            this.text = text;
        }
    }
}

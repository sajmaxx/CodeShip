using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CigarAndDrinksSelector.Pages
{
    public class LiquorsModel : PageModel
    {
        private readonly IConfiguration _someconfig;

        public LiquorsModel(IConfiguration someconfig)
        {
            _someconfig = someconfig;
        }
        public string CustomMessage { get; set;}
        public string  Brands { get; set; }
        public void OnGet()
        {
            CustomMessage = "Ethanol Galore!";
            Brands = "Maker's Mark";
            CustomMessage = _someconfig["PublicWarning"];
        }
    }
}

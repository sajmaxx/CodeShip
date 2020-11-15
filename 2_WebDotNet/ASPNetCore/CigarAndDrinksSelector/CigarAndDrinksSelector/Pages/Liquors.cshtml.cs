using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CigarAccessService;
using CigarsDrinks.Core.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CigarAndDrinksSelector.Pages
{
    public class LiquorsModel : PageModel
    {
        private readonly IConfiguration _someconfig;
        private ILiquorService _myLiquorService;
        public IEnumerable<Liqor> Liqors;

        public LiquorsModel(IConfiguration someconfig, ILiquorService myLiquorService)
        {
            _someconfig = someconfig;
            _myLiquorService = myLiquorService;
        }

        public string CustomMessage { get; set;}
        public string  Brands { get; set; }
        public void OnGet(string searchLiqors)
        {
            //CustomMessage = "Ethanol Galore!";
            //Brands = "Maker's Mark";
            CustomMessage = _someconfig["PublicWarning"];
            Liqors = string.IsNullOrEmpty(searchLiqors)
                ? _myLiquorService.GetLiqorsList()
                : _myLiquorService.GetLiqorListByName(searchLiqors);
            //Liqors = _myLiquorService.GetLiqorsList();

        }
    }
}

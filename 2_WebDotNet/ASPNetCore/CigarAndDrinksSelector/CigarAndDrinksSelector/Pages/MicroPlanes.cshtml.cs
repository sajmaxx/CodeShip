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
    public class MicroPlanesModel : PageModel
    {
        private readonly IConfiguration _someconfig;
        private IMicroAirplane _microplaneService;
        public IEnumerable<MicroPlane> MicroPlanes;

        public MicroPlanesModel(IConfiguration somecfg, IMicroAirplane microAirplaneService)
        {
            _someconfig = somecfg;
            _microplaneService = microAirplaneService;

        }
        public void OnGet()
        {
            MicroPlanes = _microplaneService.GetMicroPlanes();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spacecrafts.Website.Models;
using Spacecrafts.Website.Services;

namespace Spacecrafts.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public  SpaceCraftJsonService SpaceCraftServ { get; set; }

        public IEnumerable<SpaceCraft> SpaceCrafts {get; private set;}

        public IndexModel(ILogger<IndexModel> logger,
            SpaceCraftJsonService spacecraftserv)
        {
            _logger = logger;
            SpaceCraftServ = spacecraftserv;

        }

        public void OnGet()
        {
            SpaceCrafts = SpaceCraftServ.GetSpaceCrafts();
        }
    }
}

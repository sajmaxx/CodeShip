using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondadoTacos.Models;
using CondadoTacos.Services;

namespace CondadoTacos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, TacoJSONService tacoService)
        {
            _logger = logger;
            TacoService = tacoService;
        }

        public TacoJSONService TacoService { get; }
        public IEnumerable<Taco> Tacos {get; private set;}

        public void OnGet()
        {
            Tacos = TacoService.GetTacos();
        }
    }
}

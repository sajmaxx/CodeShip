using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CigarAccessService;
using CigarsDrinks.Core.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CigarAndDrinksSelector.Pages
{
    public class CigarsModel : PageModel
    {
        private readonly  ICigarData _cigarData;
        public IEnumerable<Cigar> CigarsList { get; set;}


        public CigarsModel(ICigarData somecigarData)
        {
            this._cigarData = somecigarData;
        }
        public void OnGet()
        {
            CigarsList = _cigarData.GetCigarsList();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CigarAndDrinksSelector.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _fullName = "baba";
        }
        private  string _fullName;

        public string FullName  
        {
            get { return _fullName; }
            set { _fullName = value;}
        }

        public string NoneYa { get; set;}


        public string NoneYaNo  {get; set;}

        public void OnGet()
        {
            ///REFACTOR PRACTICE
            
            //#1ST Control Shift R  = all refactoring options in a single menu

            
            var Whateva = DoTheInitialize();

            Whateva.Add(44.6);

            var yy = CalcutleTheY(10);

            Console.WriteLine(yy);

        }

        private static int CalcutleTheY(int xx)
        {
            var sss = xx + 100 + xx ^ 2;

            int whataguy = sss + xx * 34 / 2;

            int yy = xx + whataguy;
            return yy;
        }

        private static List<double> DoTheInitialize()
        {
            var allNumbers = new List<int>();

            var Whateva = new List<double>();

            var nameList = new List<string>();
            return Whateva;
        }
    }
}

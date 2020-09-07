using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondApp
{
    class MainWindowViewModel
    {
        string _firstContent = "Volbeat";
        string _secondConetent = "FiveFingerDeathPunch";


        public string FirstContent
        {
            get => _firstContent;
            set => _firstContent = value;
        }

        public string SecondConetent
        {
            get => _secondConetent;
            set => _secondConetent = value;
        }
    }
}

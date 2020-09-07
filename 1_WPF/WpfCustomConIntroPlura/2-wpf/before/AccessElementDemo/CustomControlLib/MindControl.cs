using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlLib
{

    public class MindControl :  Control
    {
        private const string tblockpart = "PART_TextBlockMain";
        static MindControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MindControl), new FrameworkPropertyMetadata(typeof(MindControl)));
        }

        public override void OnApplyTemplate()
        {

            base.OnApplyTemplate();

            var textblocky =  GetTemplateChild(tblockpart) as TextBlock;

            if (textblocky != null)
            {

                textblocky.Text = " mockba b cccp";

            }
        }
    }
}

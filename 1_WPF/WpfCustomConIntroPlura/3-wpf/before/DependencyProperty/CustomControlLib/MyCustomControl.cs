using System;
using System.CodeDom;
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
    public class MyCustomControl : Control
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }


        public MyCustomControl()
        {
            //This is the only way to set and get from a Static Readonly DependencyProperty without a "wrapper" refer $$$ below
         //   SetValue(TextaProperty,"bababababa");
         //   var valuetester = GetValue(TextaProperty);
        }



        public static readonly DependencyProperty TextaProperty =  DependencyProperty.Register("Texta", typeof(string), typeof(MyCustomControl));
        //$$$ Set Wrapper 
        public string Texta  //strongly typed don't do fancy stuff in here
        {
            get {return (string)GetValue(TextaProperty);}
            set { SetValue(TextaProperty, value);}
        }

        ///Do 7 Dependency Properties
        ///
        

        //#1 
        public static readonly DependencyProperty CarCostProperty = DependencyProperty.Register("CarCost", typeof(double), typeof(MyCustomControl));
        public double CarCost //Register
        {
            get { return (double)GetValue(CarCostProperty); }
            set {SetValue(CarCostProperty, value);}
        }


        //#2
        public static readonly DependencyProperty CarYearProperty = DependencyProperty.Register("CarYear", typeof(int), typeof(MyCustomControl));
        public int CarYear //Wrapper to the DP
        {
            get { return (int)GetValue(CarYearProperty);}
            set {SetValue(CarYearProperty, value);}
        }

        //#3
        public static readonly DependencyProperty CarVINProperty = DependencyProperty.Register("CarVIN", typeof(Guid), typeof(MyCustomControl));
        public Guid CarVIN //Wrapper to the DP
        {
            get { return (Guid)GetValue(CarVINProperty);}
            set { SetValue(CarVINProperty, value);}
        }


        //#4
        public static readonly DependencyProperty CarMfgProperty = DependencyProperty.Register("CarMfg", typeof(string), typeof(MyCustomControl));
        public string CarMfg //Wrapper to the DP
        {
            get { return (string)GetValue(CarMfgProperty);}
            set { SetValue(CarMfgProperty, value);}
        }


        //#5
        public static readonly DependencyProperty CarModelProperty = DependencyProperty.Register("CarModel", typeof(int), typeof(MyCustomControl));
        public int CarModel //Wrapper to the DP
        {
            get { return (int)GetValue(CarModelProperty);}
            set { SetValue(CarModelProperty, value);}
        }

        //#6
        public static readonly DependencyProperty CarWarrantyProperty = DependencyProperty.Register("CarWarranty", typeof(int), typeof(MyCustomControl));
        public int CarWarranty //Wrapper to the DP
        {
            get { return (int)GetValue(CarWarrantyProperty); }
            set { SetValue(CarWarrantyProperty, value); }
        }

        public static readonly DependencyProperty CarTitleProperty = DependencyProperty.Register("CarTitle", typeof(string), typeof(MyCustomControl));

        public string CarTitle
        {
            get { return  (string) GetValue(CarTitleProperty);}
            set { SetValue(CarTitleProperty, value);}
        }



    }
}

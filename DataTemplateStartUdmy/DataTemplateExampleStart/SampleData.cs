using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace DataTemplateExampleStart
{
   public class SampleData
    {
        public ObservableCollection<Employee> EmployeeList = new ObservableCollection<Employee>();

        public SampleData()
        {
            EmployeeList.Add(new Employee() { EmployeeName = "Mark Long" });
            EmployeeList.Add(new Employee() { EmployeeName = "Frank Hampton" });
            EmployeeList.Add(new Employee() { EmployeeName = "Jessica Chambly" });
            EmployeeList.Add(new Employee() { EmployeeName = "Lauren Nicolette" });
            EmployeeList.Add(new Employee() { EmployeeName = "Janet Roberts" });

        }
    }
}

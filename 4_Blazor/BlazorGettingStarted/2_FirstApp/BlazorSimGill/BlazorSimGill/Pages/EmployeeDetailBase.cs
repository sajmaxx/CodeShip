using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BlazorSimGill.Services;

namespace BlazorSimGill.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public Employee theEmplo { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataServices EmployeeDataService { get; set;}


        protected async Task OnInitializedAsync()
        {
            theEmplo = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
           
        }

        

    }
}

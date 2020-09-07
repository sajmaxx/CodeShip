using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BlazorSimGill.Services
{
    public interface IEmployeeDataServices
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeDetails(int employeeId);

        Task<Employee> AddEmployee(Employee newEmploy);

        Task UpdateEmployee(Employee updEmploy);

        Task DeleteEmployee(Employee delEmploy);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BlazorSimGill.Services
{
    public class EmployeeDataService : IEmployeeDataServices
    {
        
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>( await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() {PropertyNameCaseInsensitive = true} );
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
           return  await JsonSerializer.DeserializeAsync<Employee>( await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() {PropertyNameCaseInsensitive = true} ); 
        }

        public Task<Employee> AddEmployee(Employee newEmploy)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee updEmploy)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(Employee delEmploy)
        {
            throw new NotImplementedException();
        }
    }
}

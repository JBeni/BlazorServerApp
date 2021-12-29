using Blazor.Data.Responses;
using Blazor.Models;

namespace Blazor.Data.Interfaces
{
    public interface IEmployeeService
    {
        public List<EmployeeResponse> GetAllEmployees();
        public void AddEmployee(EmployeeResponse employee);
        public void UpdateEmployee(EmployeeResponse employee);
        public EmployeeResponse GetEmployeeData(int id);
        public void DeleteEmployee(int id);
        public List<CityResponse> GetCitiesData();
    }
}

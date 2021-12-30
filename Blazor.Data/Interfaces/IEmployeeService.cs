namespace Blazor.Data.Interfaces
{
    public interface IEmployeeService
    {
        public List<EmployeeResponse> GetAllEmployees();
        public Task AddEmployee(EmployeeResponse employee);
        public Task UpdateEmployee(EmployeeResponse employee);
        public EmployeeResponse GetEmployeeData(int id);
        public Task DeleteEmployee(int id);
        public List<CityResponse> GetCitiesData();
    }
}

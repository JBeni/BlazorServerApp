﻿using Blazor.Models;

namespace Blazor.Data.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee GetEmployeeData(int id);
        public void DeleteEmployee(int id);
        public List<City> GetCityData();
    }
}

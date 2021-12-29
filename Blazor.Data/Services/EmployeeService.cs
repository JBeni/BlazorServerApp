using Blazor.Data.Interfaces;
using Blazor.Data.Persistence;
using Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _db.Employees.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee? employee = _db.Employees.Find(id);

                if (employee != null)
                {
                    _db.Entry(employee).State = EntityState.Detached;
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _db.Employees.Find(id);

                if (employee != null)
                {
                    _db.Employees.Remove(employee);
                }
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<City> GetCitiesData()
        {
            try
            {
                return _db.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}

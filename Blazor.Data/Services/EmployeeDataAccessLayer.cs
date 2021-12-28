using Blazor.Data.Interfaces;
using Blazor.Data.Persistence;
using Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Data.Services
{
    public class EmployeeDataAccessLayer : IEmployeeService
    {
        private ApplicationDbContext db;

        public EmployeeDataAccessLayer(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.AsNoTracking().ToList();
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
                db.Employees.Add(employee);
                db.SaveChanges();
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
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
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
                Employee? employee = db.Employees.Find(id);

                if (employee != null)
                {
                    db.Entry(employee).State = EntityState.Detached;
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
                Employee? employee = db.Employees.Find(id);

                if (employee != null)
                {
                    db.Employees.Remove(employee);
                }
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<City> GetCityData()
        {
            try
            {
                return db.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}

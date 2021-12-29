using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blazor.Data.Interfaces;
using Blazor.Data.Responses;
using Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<EmployeeResponse> GetAllEmployees()
        {
            try
            {
                var result = _dbContext.Employees.AsNoTracking()
                    .ProjectTo<EmployeeResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public void AddEmployee(EmployeeResponse employee)
        {
            try
            {
                var entity = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                _dbContext.Employees.Add(entity);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(EmployeeResponse employee)
        {
            try
            {
                var entity = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                _dbContext.Employees.Update(entity);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public EmployeeResponse GetEmployeeData(int id)
        {
            try
            {
                var employee = _dbContext.Employees.AsNoTracking()
                    .Where(x => x.EmployeeId == id)
                    .ProjectTo<EmployeeResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                if (employee != null)
                {
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
                Employee? employee = _dbContext.Employees.Find(id);

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                }
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<CityResponse> GetCitiesData()
        {
            try
            {
                var result = _dbContext.Cities.AsNoTracking()
                    .ProjectTo<CityResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}

namespace Blazor.Application.Services
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
                var result = _dbContext.Employees
                    .ProjectTo<EmployeeResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddEmployee(EmployeeResponse employee)
        {
            try
            {
                var entity = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                if (entity != null) return;

                entity = new Employee
                {
                    City = employee.City,
                    Name = employee.Name,
                    Gender = employee.Gender,
                    Department = employee.Department
                };

                _dbContext.Employees.Add(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEmployee(EmployeeResponse employee)
        {
            try
            {
                Employee? entity = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                if (entity == null) return;

                entity.City = employee.City;
                entity.Name = employee.Name;
                entity.Gender = employee.Gender;
                entity.Department = employee.Department;

                _dbContext.Employees.Update(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
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

        public async Task DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    await _dbContext.SaveChangesAsync(new CancellationToken());
                }
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

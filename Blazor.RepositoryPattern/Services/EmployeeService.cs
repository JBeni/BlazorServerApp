namespace Blazor.RepositoryPattern.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EmployeeResponse> GetAllEmployees()
        {
            try
            {
                var result = _unitOfWork.Employees.GetAll();
                var employees = _mapper.Map<List<EmployeeResponse>>(result);
                return employees;
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
                var entity = _unitOfWork.Employees.Get(employee.EmployeeId);
                if (entity != null) return;

                entity = new Employee
                {
                    City = employee.City,
                    Name = employee.Name,
                    Gender = employee.Gender,
                    Department = employee.Department
                };

                _unitOfWork.Employees.Add(entity);
                _unitOfWork.Complete();
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
                var entity = _unitOfWork.Employees.Get(employee.EmployeeId);
                if (entity == null) return;

                entity.City = employee.City;
                entity.Name = employee.Name;
                entity.Gender = employee.Gender;
                entity.Department = employee.Department;

                _unitOfWork.Employees.Update(entity);
                _unitOfWork.Complete();
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
                var result = _unitOfWork.Employees.Get(id);
                var employee = _mapper.Map<EmployeeResponse>(result);

                return employee == null ? throw new ArgumentNullException() : employee;
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
                Employee? employee = _unitOfWork.Employees.Get(id);

                if (employee != null)
                {
                    _unitOfWork.Employees.Delete(employee);
                    _unitOfWork.Complete();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

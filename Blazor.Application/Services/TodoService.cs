namespace Blazor.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TodoService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CompleteTodo(int todoId)
        {
            try
            {
                var entity = _dbContext.Todos.FirstOrDefault(x => x.Id == todoId);
                if (entity == null) return;

                entity.IsCompleted = true;

                _dbContext.Todos.Update(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateTodo(TodoResponse todo)
        {
            try
            {
                var entity = _dbContext.Todos.FirstOrDefault(x => x.Id == todo.Id);
                if (entity != null) return;

                entity = new Todo
                {
                    Title = todo.Title,
                    IsCompleted = false
                };

                _dbContext.Todos.Add(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public List<TodoResponse> GetAllTodos()
        {
            try
            {
                var result = _dbContext.Todos
                    .ProjectTo<TodoResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public TodoResponse GetTodoData(int id)
        {
            try
            {
                var employee = _dbContext.Todos.AsNoTracking()
                    .Where(x => x.Id == id)
                    .ProjectTo<TodoResponse>(_mapper.ConfigurationProvider)
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
    }
}

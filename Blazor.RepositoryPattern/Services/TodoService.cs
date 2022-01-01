namespace Blazor.RepositoryPattern.Services
{
    public class TodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CompleteTodo(int todoId)
        {
            try
            {
                var entity = _unitOfWork.Todos.Get(todoId);
                if (entity == null) return;

                entity.IsCompleted = true;

                _unitOfWork.Todos.Update(entity);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void CreateTodo(TodoResponse todo)
        {
            try
            {
                var entity = _unitOfWork.Todos.Get(todo.Id);
                if (entity != null) return;

                entity = new Todo
                {
                    Title = todo.Title,
                    IsCompleted = false
                };

                _unitOfWork.Todos.Add(entity);
                _unitOfWork.Complete();
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
                var result = _unitOfWork.Todos.GetAll();
                var todos = _mapper.Map<List<TodoResponse>>(result);
                return todos;
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
                var result = _unitOfWork.Todos.Get(id);
                var todo = _mapper.Map<TodoResponse>(result);

                if (todo == null) throw new ArgumentNullException();
                return todo;
            }
            catch
            {
                throw;
            }
        }
    }
}

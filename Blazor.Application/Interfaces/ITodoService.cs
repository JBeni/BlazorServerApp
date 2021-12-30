namespace Blazor.Application.Interfaces
{
    public interface ITodoService
    {
        Task CreateTodo(TodoResponse todo);
        Task CompleteTodo(int todoId);

        public List<TodoResponse> GetAllTodos();
        public TodoResponse GetTodoData(int id);
    }
}

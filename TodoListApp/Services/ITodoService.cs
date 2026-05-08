using TodoListApp.DTOs;

namespace TodoListApp.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoResponseDto>> GetAllAsync();
    Task<TodoResponseDto?> GetByIdAsync(int id);
    Task<TodoResponseDto> CreateAsync(CreateTodoDto dto);
    Task<bool> UpdateAsync(int id, UpdateTodoDto dto);
    Task<bool> DeleteAsync(int id);
}
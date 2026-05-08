using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.DTOs;
using TodoListApp.Models;

namespace TodoListApp.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoResponseDto>> GetAllAsync()
    {
        var items = await _context.Todos.ToListAsync();
        return items.Select(t => new TodoResponseDto(t.Id, t.Title, t.IsCompleted, t.CreatedAt));
    }

    public async Task<TodoResponseDto?> GetByIdAsync(int id)
    {
        var item = await _context.Todos.FindAsync(id);
        return item is null ? null : new TodoResponseDto(item.Id, item.Title, item.IsCompleted, item.CreatedAt);
    }

    public async Task<TodoResponseDto> CreateAsync(CreateTodoDto dto)
    {
        var todo = new TodoItem { Title = dto.Title };
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return new TodoResponseDto(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTodoDto dto)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null) return false;

        todo.Title = dto.Title;
        todo.IsCompleted = dto.IsCompleted;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null) return false;

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}
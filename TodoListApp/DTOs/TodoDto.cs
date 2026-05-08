namespace TodoListApp.DTOs;

public record CreateTodoDto(string Title);
public record UpdateTodoDto(string Title, bool IsCompleted);
public record TodoResponseDto(int Id, string Title, bool IsCompleted, DateTime CreatedAt);
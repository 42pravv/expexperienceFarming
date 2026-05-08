using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=todos.db"));
builder.Services.AddScoped<ITodoService, TodoService>();

// Добавляем CORS (ОЧЕНЬ ВАЖНО!)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Create database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

// Используем CORS (ДО MapControllers!)
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
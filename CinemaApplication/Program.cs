using BusinessLogic;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices();
builder.Services.AddBusinessLogicServices();

builder.Services.AddControllers();

builder.Services.AddDbContext<CinemaContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CinemaContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
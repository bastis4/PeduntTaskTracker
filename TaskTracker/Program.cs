using TaskTracker.DAL;
using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Interfaces;
using TaskTracker.DAL.Repositories;
using TaskTracker.Services;
using TaskTracker.Interfaces;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TaskTracker.DAL.Models;
using Microsoft.Extensions.Configuration;
using TaskTracker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

builder.Services.AddDbContext<TaskTrackerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IIntegrationService, RabbitMQService>();

builder.Services.AddControllers().AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Filter()
        .OrderBy()
        .SetMaxTop(50)
        .Expand()
        .Select()
        .Count()
    ); 

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<ProjectEntity>("Projects");
    builder.EntitySet<TodoTaskEntity>("Tasks");

    return builder.GetEdmModel();
}

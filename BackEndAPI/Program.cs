using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Service.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BackEndAPI.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApiDBContext>(options => {
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(conn);
});

builder.Services.AddScoped<IProjectCRUD, ProjectCRUD>();
builder.Services.AddScoped<IProfessorCRUD, ProfessorCRUD>();
builder.Services.AddScoped<IStudentCRUD, StudentCRUD>();
builder.Services.AddScoped<ISkillCRUD, SkillCRUD>();
// builder.Services.AddScoped<IProjectSkillCRUD, ProjectSkillCRUD>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


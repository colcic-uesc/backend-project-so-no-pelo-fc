using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Service.DataBase.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IProjectCRUD, ProjectCRUD>();
builder.Services.AddScoped<IProfessorCRUD, ProfessorCRUD>();
builder.Services.AddScoped<IStudentCRUD, StudentCRUD>();
builder.Services.AddScoped<ISkillCRUD, SkillCRUD>();
builder.Services.AddScoped<IProjectSkillCRUD,ProjectSkillCRUD>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

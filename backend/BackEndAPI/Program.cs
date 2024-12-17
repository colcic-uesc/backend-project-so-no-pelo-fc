using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Service.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BackEndAPI.Middlewares;
using BackEndAPI.Service.Auth;

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
builder.Services.AddScoped<IUserCRUD, UserCRUD>();
builder.Services.AddScoped<AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();

builder.Services.AddCors(options => {
            options.AddPolicy("AllowReactApp", policy => {
                policy.WithOrigins(builder.Configuration.GetValue<string>("ReactAppUrl")!)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
 
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<AddNameVersionMiddleware>();
app.UseMiddleware<JwtTokenCheckMiddleware>();

app.MapControllers();

app.Run();


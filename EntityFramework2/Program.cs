using EntityFramework2.Data;
using EntityFramework2.Entity;
using EntityFramework2.Mapper;
using EntityFramework2.Repostory;
using EntityFramework2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbContextClass>();
builder.Services.AddScoped<IStudent, StudentRepostory>();
builder.Services.AddScoped<ICourse,CourseRepostory>();
builder.Services.AddAutoMapper(typeof(EFMapper));
builder.Services.AddControllers();
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

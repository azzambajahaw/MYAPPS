using AppOne.Models;
using Microsoft.EntityFrameworkCore;
using AppOne.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var x= builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(x));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient(typeof(IClassService), typeof(ClassService));
builder.Services.AddTransient(typeof(IStudntService), typeof(StudntService));
//builder.Services.AddScoped<IClassService, ClassService>();
//builder.Services.AddScoped<IStudntService, StudntService>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
// void ConfigureServices(IServiceCollection services)
//{
//    services.AddTransient<IStudntService, AppOne.Services.StudntService>();
//    services.AddTransient<IClassService, AppOne.Services.ClassService>();
//    // Other service configurations...
//}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

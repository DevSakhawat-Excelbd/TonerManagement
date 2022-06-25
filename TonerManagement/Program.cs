using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TonerManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dbcontext to Services
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("TonerCon")));

//builder.Services.AddDbContext<DataContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseTrackerCon")));

builder.Services.AddCors(op=>
{
   op.AddPolicy("AllowAll", new CorsPolicyBuilder()
      .AllowAnyHeader()
      .AllowAnyMethod()
      .SetIsOriginAllowed(origin => true)
      .AllowCredentials()
      .Build()
      );
});



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

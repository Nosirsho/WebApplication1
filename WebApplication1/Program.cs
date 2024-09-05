using WebApplication1.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var conStr =  builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CafeDbContext>(options=>options.UseNpgsql(conStr));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
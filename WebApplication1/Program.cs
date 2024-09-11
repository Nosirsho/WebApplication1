using FluentValidation;
using WebApplication1.Contracts.Place;
using WebApplication1.Contracts.PlaceCategory;
using WebApplication1.DataAccess;
using WebApplication1.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<CafeDbContext>();
builder.Services.AddScoped<IValidator<CreatePlaceCategoryRequest>, PlaceCategoryValidation>();
builder.Services.AddScoped<IValidator<CreatePlaceRequest>, PlaceValidation>();

var app = builder.Build();
using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<CafeDbContext>();
await dbContext.Database.EnsureCreatedAsync();
//var initializeDb = new InitializeDb(dbContext);
//initializeDb.Initialize();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
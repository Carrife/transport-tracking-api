using Lab.Data;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;
using Lab.Repositories;
using Lab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("Name=DefaultConnection");
});

builder.Services.AddCors();

using (AppDbContext context = new AppDbContext())
{
    context.Database.Migrate();

    if (!context.SuperDictionaries.Any())
    {
        context.SuperDictionaries.Add(new SuperDictionary { Id = 1, Name = "���������", DictionaryId = 1 });
        context.SuperDictionaries.Add(new SuperDictionary { Id = 2, Name = "�������", DictionaryId = 1 });
    }

    context.SaveChanges();
}

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.
builder.Services.AddScoped<ITransportService,TransportService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<ISuperDictionaryService, SuperDictionaryService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTransportChoiceService, UserTransportChoiceService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
  ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

app.Run();

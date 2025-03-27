using Microsoft.EntityFrameworkCore;
using Romanel.Evaluation.Application.Commands;
using Romanel.Evaluation.Application.Interfaces;
using Romanel.Evaluation.domain.Interfaces;
using Romanel.Evaluation.Infrastructure.Data;
using Romanel.Evaluation.Infrastructure.EventStore;
using Romanel.Evaluation.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteReadRepository, ClienteReadRepository>();
builder.Services.AddScoped<IEventStore, SqlEventStore>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarClienteCommand).Assembly));

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

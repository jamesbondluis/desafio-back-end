using DesafioBackEnd.BLL.Profiles;
using DesafioBackEnd.BLL.Repositories;
using DesafioBackEnd.BLL.Services;
using DesafioBackEnd.DAL.Data;
using DesafioBackEnd.DAL.Profiles;
using DesafioBackEnd.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddAutoMapper(typeof(MapProfilesDAL));
builder.Services.AddAutoMapper(typeof(MapProfilesBLL));
builder.Services.AddDbContext<AbstractDbContext, EFIMContext>(options => 
options.UseInMemoryDatabase("MyDb"));

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

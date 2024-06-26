using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Apresentacao"))
);

builder.Services.AddScoped<IServEvento, ServEvento>();
builder.Services.AddScoped<IRepoEvento, RepoEvento>();
builder.Services.AddScoped<IServComprador, ServComprador>();
builder.Services.AddScoped<IRepoComprador, RepoComprador>();
builder.Services.AddScoped<IServVenda, ServVenda>();
builder.Services.AddScoped<IRepoVenda, RepoVenda>();

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

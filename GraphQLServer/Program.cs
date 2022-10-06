using GraphQLServer.Data;
using GraphQLServer.MethodExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext configuration
builder.Services.AddDbContext<BlogContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnection"),
    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "blog"))
);

// GraphQL configuration
builder.Services.AddGraphQLServer();

var app = builder.Build();

await app.ConfigureMigrationsAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();

app.MapControllers();

app.Run();

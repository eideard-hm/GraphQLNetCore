using GraphQLServer.Data;
using GraphQLServer.MethodExtensions;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// GraphQL configuration
builder.Services.AddGraphQLServer()
                .AddQueryType()
                .AddGraphQLServerTypes()
                .RegisterDbContext<BlogContext>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

// DbContext configuration
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnection"),
    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "blog"))
);

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

app.UseCors(c => c.AllowAnyHeader().WithMethods("POST").AllowAnyOrigin());

app.MapGraphQL();

app.MapControllers();

app.Run();

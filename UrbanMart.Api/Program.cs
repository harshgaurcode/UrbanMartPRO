using Microsoft.EntityFrameworkCore;
using UrbanMart.BuildingBlocks.Domain;
using UrbanMart.Modules.Identity.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<IdentityDbContext>(options =>
//    options.UseNpgsql(
//        builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgres"),
        npgsqlOptions =>
        {
            npgsqlOptions.MigrationsHistoryTable(
                "__EFMigrationsHistory",
                Schemas.Identity);
        }));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
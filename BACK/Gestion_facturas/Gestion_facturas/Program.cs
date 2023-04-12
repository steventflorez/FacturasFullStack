//1. Using to work with Entity Franwork

using Microsoft.EntityFrameworkCore;
using Gestion_facturas.DataAcces;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

//2 conection with SQL SERVER express

const string CONECTIONNAME = "GestionFacturasDB";
var connectionString = builder.Configuration.GetConnectionString(CONECTIONNAME);

//3 add Context

builder.Services.AddDbContext<FacturasDBContext>(Options => Options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();

//4. add Custom Services (folder Services )
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//5. CORS configuration
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "CorsPolicy", builder => 
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
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

//6. Tell app to use CORS

app.UseCors("CorsPolicy");

app.Run();

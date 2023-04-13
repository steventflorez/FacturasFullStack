//1. Using to work with Entity Franwork

using Microsoft.EntityFrameworkCore;
using Gestion_facturas.DataAcces;
using Microsoft.CodeAnalysis.Options;
using Gestion_facturas;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//2 conection with SQL SERVER express

const string CONECTIONNAME = "GestionFacturasDB";
var connectionString = builder.Configuration.GetConnectionString(CONECTIONNAME);

//3 add Context to services of builder

builder.Services.AddDbContext<FacturasDBContext>(Options => Options.UseSqlServer(connectionString));

//7. add Service of the Container
//TODO: 
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//4. add Custom Services (folder Services )
//builder.Services.AddScoped<IStudents>
builder.Services.AddControllers();
//TODO: Add the rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//8 TODO: CONFIG SWAGGER TO TAKE CARE OF AUTORIZATION OF JWT
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("userOnly", "User"));
});

//9 config Swagger to take care of autorization of JWT
builder.Services.AddSwaggerGen(options =>
{
    //we define the security for autorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT AUTHORIZATION HEADER USING BEARER SHEME"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme

                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
             new string[]{}
        }
    });
});

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

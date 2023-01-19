using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameDataApp.Data;
using Microsoft.OpenApi.Models;
using GameDataApp.DAL;
using GameDataApp.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameDataAppContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("GameDataAppContext")
                    ?? throw new InvalidOperationException("Connection string 'GameDataAppContext' not found.")));

builder.Services.AddScoped<GenericRepository<Inventory>>();
builder.Services.AddScoped<GenericRepository<Item>>();
builder.Services.AddScoped<GenericRepository<Player>>();
builder.Services.AddScoped<GenericRepository<Quest>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Game Data Application",
        Description = "This is an application for managing and performing CRUD operations on a game database.",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Dragomir Alexandru-Mario",
            Email = "dragomario2k@gmail.com",
            Url = new Uri(uriString: "https://www.dummy.com")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);

    c.CustomOperationIds(apiDescription =>
    {
        return apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
            ? methodInfo.Name
            : null;
    });
}).AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameDataApp v1");
        c.DisplayOperationId();
    });
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

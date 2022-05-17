using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.Data;
using PlatformService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IContactRepo, ContactRepo>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformsService", Version = "Version1" })
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        }
    );
}
PrepDb.PrepPopulation(app);

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMvcWithDefaultRoute();


app.MapControllers();

app.Run();

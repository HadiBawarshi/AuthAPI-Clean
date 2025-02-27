using Auth.Application.Extensions;
using Auth.Core.Middlewares;
using Auth.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Db context and Identity
builder.Services.AddIdentityDbContext(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationServices();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddInfrastructureIdentityServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth.API", Version = "v1" });
});

//JWT Authentication
builder.Services.AddJWTAuthentication(builder.Configuration);

var app = builder.Build();


//Exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth.API v1"));
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints =>
 {
     endpoints.MapControllers();
 });




app.Run();

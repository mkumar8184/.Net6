using JwtTokenSample.Entity;
using JwtTokenSample.Extensions;
using LeasePortal.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<JwtTokenTestContext>(options
                => options.UseSqlServer(builder.Configuration["jwtSetting:dbContext"]));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.
     AddJwtAuthentications(builder.Configuration["jwtSetting:secret"])
    .AddSwaggerGenService();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
HttpContextHandler.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
app.UseAuthorization();

app.MapControllers();

app.Run();

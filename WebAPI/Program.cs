using Application.Handlers;
using Application.Handlers.Activity;
using Infrastructure.Data;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins", policy =>
    {
        policy
            .AllowAnyHeader()
            .WithOrigins("http://localhost:5173", "https://localhost:7000")
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<Jwt>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMediatR(typeof(CreateActivityHandler));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("_myAllowSpecificOrigins");


app.MapControllers();

app.Run();


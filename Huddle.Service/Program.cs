using Huddle.Business.Managers;
using Huddle.DbContext;
using Huddle.Interfaces.ManagersInterfaces;
using Huddle.Interfaces.RepositoryInterfaces;
using Huddle.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddTransient<IGroupsManager, GroupsManager>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IGroupsValidationManager, GroupsValidationManager>();
builder.Services.AddTransient<IGroupsRepository, GroupsRepository>();
builder.Services.AddTransient<IUsersManager, UsersManager>();


builder.Services.AddDbContext<HuddleDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("HuddleDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:3000").WithMethods("GET", "POST", "DELETE", "PUT").WithHeaders("Content-Type"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

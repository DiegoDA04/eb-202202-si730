using Microsoft.EntityFrameworkCore;
using si730ebu20201c334.API.Loyalty.Domain.Repositories;
using si730ebu20201c334.API.Loyalty.Domain.Services;
using si730ebu20201c334.API.Loyalty.Persistence.Repositories;
using si730ebu20201c334.API.Loyalty.Services;
using si730ebu20201c334.API.Shared.Domain.Repositories;
using si730ebu20201c334.API.Shared.Persistence.Contexts;
using si730ebu20201c334.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.EnableAnnotations();
    }
);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IRewardService, RewardService>();

builder.Services.AddAutoMapper(
    typeof(si730ebu20201c334.API.Loyalty.Mapping.ResourceToModelProfile),
    typeof(si730ebu20201c334.API.Loyalty.Mapping.ModelToResourceProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
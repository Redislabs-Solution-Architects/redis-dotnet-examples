using Redis.DotNet.Examples.QueryParams;
using Redis.DotNet.Examples.QueryParams.Helpers;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.DotNet.Examples.QueryParams.Services;
using Redis.OM;
using Redis.OM.Contracts;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST");
var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");

builder.Services.Configure<DemoOptions>
        (builder.Configuration.GetSection("DemoOptions"));

var settings = builder.Configuration
    .GetSection(DemoOptions.Section)
    .Get<DemoOptions>();

Console.WriteLine($"{redisHost}:{redisPort}");
Console.WriteLine($"Before Connecting");

var redisConnection = await ConnectionMultiplexer.ConnectAsync($"{redisHost}:{redisPort}, ssl=false"); // Replace with your Redis server connection details
var provider = new RedisConnectionProvider(redisConnection);

// Add services to the container.
builder.Services.AddSingleton<IRedisConnectionProvider>(provider);

builder.Services.AddHostedService<StartupService>();

builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();


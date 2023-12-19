using System.Linq;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using NRedisStack.Search.Literals.Enums;
using Redis.DotNet.NRedisStack.QueryParams.Helpers;
using Redis.DotNet.NRedisStack.QueryParams.Models.Domain;
using Redis.DotNet.NRedisStack.QueryParams.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST");
var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");

Console.WriteLine($"{redisHost}:{redisPort}");
Console.WriteLine($"Before Connecting");

var redisConnection = await ConnectionMultiplexer.ConnectAsync($"{redisHost}:{redisPort}, ssl=false"); // Replace with your Redis server connection details

builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

var db = redisConnection.GetDatabase();
var ft = db.FT();

await RedisHelper.DeleteAllKeys(redisConnection, db);

if (ft._List().Length == 0)
{
    var customerSchema = new Schema()
    .AddTextField(new FieldName("$.FullName", "fullname"))
    .AddTextField(new FieldName("$.Email", "email"))
    .AddTextField(new FieldName("$.Address.AddressLine1", "address"));

    //Create Index
    ft.Create(
        "idx:customers",
        new FTCreateParams().On(IndexDataType.JSON).Prefix("customer:"),
        customerSchema);
}

await RedisHelper.SeedCustomers(db);

// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
builder.Services.AddScoped<ICustomerService, CustomerService>();

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


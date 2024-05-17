using Microsoft.Azure.Cosmos;
using System.Configuration;
using System.Text.Json.Serialization;
using Task_Capital_Placement.Core.Models;
using Task_Capital_Placement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
string sectionName = typeof(CosmosDbSettings).Name;
CosmosDbSettings config = new CosmosDbSettings();
builder.Configuration.GetSection(sectionName).Bind(config);
builder.Services.AddSingleton(config);
builder.Services.AddSingleton((option) =>
{
    var cosmosDbClientOptions = new CosmosClientOptions
    {
        ApplicationName = config.DatabaseName,
        ConnectionMode = ConnectionMode.Gateway
    };
    // Add logging to console
    var logger = LoggerFactory.Create(builder => { builder.AddConsole(); });
    var cosmosClient = new CosmosClient(config.Url, config.PrimaryKey, cosmosDbClientOptions);

    return cosmosClient;
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IProgrammeRepository, ProgrammeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

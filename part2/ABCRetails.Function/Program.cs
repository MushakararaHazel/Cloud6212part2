using ABCRetails.Function;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = FunctionsApplication.CreateBuilder(args);

// Load configuration from local.settings.json
builder.Configuration
    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Register options binding
builder.Services.Configure<StorageOptions>(builder.Configuration.GetSection("Storage"));

// Register Azure clients
builder.Services.AddSingleton(sp =>
{
    var opt = sp.GetRequiredService<IOptions<StorageOptions>>().Value;
    return new TableServiceClient(opt.Connection);
});
builder.Services.AddSingleton(sp =>
{
    var opt = sp.GetRequiredService<IOptions<StorageOptions>>().Value;
    return new BlobServiceClient(opt.Connection);
});
builder.Services.AddSingleton(sp =>
{
    var opt = sp.GetRequiredService<IOptions<StorageOptions>>().Value;
    return new QueueServiceClient(opt.Connection);
});
builder.Services.AddSingleton(sp =>
{
    var opt = sp.GetRequiredService<IOptions<StorageOptions>>().Value;
    return new ShareServiceClient(opt.Connection);
});

// Add Application Insights
builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();

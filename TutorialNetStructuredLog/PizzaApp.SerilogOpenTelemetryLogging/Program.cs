using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OpenTelemetry.Resources;
using Serilog;
using Serilog.Sinks.OpenTelemetry;

var resourceBuilder = ResourceBuilder.CreateDefault()
   .AddService("PizzaApp", serviceVersion: "1.0.0")
   .AddAttributes(new Dictionary<string, object>
   {
      ["environment"] = "development",
      ["deployment.environment"] = "local"
   });


var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{  
   services.AddTransient<IPizzaService, PizzaService>();
});
builder.UseSerilog((context, configuration) => configuration
   .WriteTo.Console()
   .WriteTo.OpenTelemetry(opt =>
   {
      opt.ResourceAttributes = resourceBuilder.Build().Attributes
         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      opt.Endpoint = "http://localhost:5341/ingest/otlp/v1/logs"; // SEQ endpoint
      opt.Protocol = OtlpProtocol.HttpProtobuf;

   })
   .Enrich.WithMachineName()
   );

var host = builder.Build();
var pizzaService = host.Services.GetRequiredService<IPizzaService>();
await pizzaService.BakePizzaAsync("Margherita", 12.99m);
await host.RunAsync();

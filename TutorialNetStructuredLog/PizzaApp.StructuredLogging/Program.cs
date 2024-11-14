using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                   builder.AddConsole();
                   builder.SetMinimumLevel(LogLevel.Debug);
                })
                .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started");

try
{
   var pizza = new Pizza("Margherita", 12.99m);
   logger.LogInformation("Created new pizza {PizzaName} with price {Price}", pizza.Name, pizza.Price);

   pizza.AddTopping("Mozzarella");
   logger.LogInformation("Added topping {Topping} to pizza {PizzaName}", "Mozzarella", pizza.Name);

   pizza.Bake();
   logger.LogInformation("Pizza {PizzaName} is baking", pizza.Name);
}
catch (Exception ex)
{
   logger.LogError(ex, "An error occurred while processing the pizza");
}

logger.LogInformation("Application ended");

using Microsoft.Extensions.Logging;
public class PizzaService : IPizzaService
{
   private readonly ILogger<PizzaService> _logger;

   public PizzaService(ILogger<PizzaService> logger)
   {
      _logger = logger;
   }

   public async Task BakePizzaAsync(string name, decimal price)
   {
      try
      {
         _logger.LogInformation("Starting to prepare pizza {Name}", name);

         var pizza = new Pizza(name, price);
         _logger.LogInformation("Created pizza {@Pizza}", pizza);

         await Task.Delay(2000); // Simulating baking time
         pizza.Cook();

         _logger.LogInformation("Pizza {@Pizza} is ready and cooked: {IsCooked}", pizza, pizza.IsCooked);
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, "Error while baking pizza {@Name}", name);
         throw;
      }
   }
}
using Serilog;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/pizza.txt", rollingInterval: RollingInterval.Day)
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName()
                .CreateLogger();

Log.Information("Application started");

try
{
   var pizza = new Pizza("Margherita", 12.99m);
   Log.Information("Created new pizza {PizzaName} with price {Price:C}", pizza.Name, pizza.Price);

   string topping = "Pomodoro";
   pizza.AddTopping("Mozzarella");
   Log.Information("Added topping {Topping} to {@Pizza}", "Mozzarella", topping, pizza);

   topping = "Mozzarella";
   pizza.AddTopping("Mozzarella");
   Log.Information("Added topping {Topping} to {@Pizza}", "Mozzarella", topping, pizza);

   pizza.Bake();
   Log.Information("Pizza {@Pizza} is baking", pizza);
}
catch (Exception ex)
{
   Log.Error(ex, "An error occurred while processing the pizza");
}
finally
{
   Log.CloseAndFlush();
}
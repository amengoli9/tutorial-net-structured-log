Console.WriteLine($"[{DateTime.Now}] Application started");

try
{
   var pizza = new Pizza("Margherita", 12.99m);
   Console.WriteLine($"[{DateTime.Now}] Created new pizza: {pizza.Name}");

   pizza.AddTopping("Pomodoro");
   Console.WriteLine($"[{DateTime.Now}] Added topping to {pizza.Name}");

   pizza.AddTopping("Mozzarella");
   Console.WriteLine($"[{DateTime.Now}] Added topping to {pizza.Name}");

   pizza.Bake();
   Console.WriteLine($"[{DateTime.Now}] Pizza {pizza.Name} is baking");
}
catch (Exception ex)
{
   Console.WriteLine($"[{DateTime.Now}] ERROR: {ex.Message}");
}

Console.WriteLine($"[{DateTime.Now}] Application ended");
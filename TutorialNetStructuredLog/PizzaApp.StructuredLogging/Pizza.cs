public class Pizza
{
   public string Name { get; }
   public decimal Price { get; }
   public List<string> Toppings { get; } = new();

   public Pizza(string name, decimal price)
   {
      Name = name;
      Price = price;
   }

   public void AddTopping(string topping) => Toppings.Add(topping);
   public void Bake() => Thread.Sleep(1000); // Simulate baking
}
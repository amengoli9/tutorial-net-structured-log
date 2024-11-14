public record Pizza(string Name, decimal Price)
{
   public bool IsCooked { get; private set; } = false;
   public void Cook() => IsCooked = true;
}

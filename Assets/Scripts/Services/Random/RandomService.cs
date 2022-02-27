namespace Services.Random
{
  public class RandomService : IRandomService
  {
    private System.Random random;

    public RandomService()
    {
      random = new System.Random();
    }

    public int Next(int min, int max) =>
      random.Next(min, max);

    public int Next(int max) => 
      Next(0, max);

    public float NextFloat() => 
      (float) NextDouble();

    public float NextFloat(float min, float max)
    {
      float number = NextFloat();
      return number * max + number * min;
    }

    public double NextDouble() => 
      random.NextDouble();

    public void UpdateSeed(int seed)
    {
      random = new System.Random(seed);
    }
  }
}
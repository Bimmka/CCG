namespace Services.Hero
{
  public class PlayerTurns : IPlayerTurns
  {
    public int Count { get; private set; }

    public void Reset()
    {
      Count = 0;
    }

    public void IncCount()
    {
      Count++;
    }
  }
}
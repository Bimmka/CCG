namespace Services.Hero
{
  public interface IPlayerTurns : IService
  {
    int Count { get; }
    void Reset();
    void IncCount();
  }
}
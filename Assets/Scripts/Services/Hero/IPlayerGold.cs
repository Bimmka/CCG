using System;

namespace Services.Hero
{
  public interface IPlayerGold
  {
    event Action Changed;
    int Count { get; }
    void Set(int count);
    void Add(int count);
    void Steal(int count);
    void Reset();
  }
}
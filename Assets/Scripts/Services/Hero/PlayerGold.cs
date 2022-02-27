using System;

namespace Services.Hero
{
  public class PlayerGold : IPlayerGold
  {
    public event Action Changed;
    public event Action Ended;

    public int Count { get; private set; }
    public int MaxCount { get; private set; }

    public void Set(int count, int maxCount)
    {
      Count = count;
      MaxCount = maxCount;
      NotifyAboutChange();
    }

    public void Add(int count)
    {
      Count += count;
      NotifyAboutChange();
    }

    public void Steal(int count)
    {
      Count -= count;
      if (Count <= 0)
      {
        Count = 0;
        NotifyAboutEnded();
      }
      NotifyAboutChange();
    }

    public void Reset()
    {
      Count = 0;
    }

    private void NotifyAboutChange() => 
      Changed?.Invoke();

    private void NotifyAboutEnded() => 
      Ended?.Invoke();
  }
}
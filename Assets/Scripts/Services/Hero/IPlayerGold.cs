﻿using System;

namespace Services.Hero
{
  public interface IPlayerGold : IService
  {
    event Action Changed;
    event Action Ended;
    int Count { get; }
    void Set(int count);
    void Add(int count);
    void Steal(int count);
    void Reset();
  }
}
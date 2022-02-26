﻿using Services.Hero;
using UnityEngine;

namespace UI.Displaying
{
  public class GoldDisplayer : MonoBehaviour
  {
    [SerializeField] private UIBar hpBar;

    private IPlayerGold gold;
    
    public void Construct(IPlayerGold gold)
    {
      this.gold = gold;
      this.gold.Changed += UpdateBar;
      UpdateBar();
    }

    private void OnDestroy()
    {
      if (gold != null)
        gold.Changed -= UpdateBar;
    }

    private void UpdateBar()
    {
      UpdateHpBar(gold.Count, 100);
    }

    private void UpdateHpBar(float current, float max) => 
      hpBar.SetValue(current, max);
  }
}
using Services.Hero;
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
      hpBar.SetValue(gold.Count, gold.MaxCount);
    }

    private void OnDestroy()
    {
      if (gold != null)
        gold.Changed -= UpdateBar;
    }

    private void UpdateBar()
    {
      UpdateHpBar(gold.Count, gold.MaxCount);
    }

    private void UpdateHpBar(float current, float max) => 
      hpBar.FillValue(current, max);
  }
}
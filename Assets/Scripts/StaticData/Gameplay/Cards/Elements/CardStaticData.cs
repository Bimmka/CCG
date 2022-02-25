using Gameplay.Cards.CardsElement.Base;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Elements
{
  [CreateAssetMenu(fileName = "CardStaticData", menuName = "Static Data / Cards /Elements/Create Card", order = 52)]
  public class CardStaticData : ScriptableObject
  {
    public int ID;
    public string Name;
    public string Description;
    public PlayingZoneType PlayingZoneType;
  }
}
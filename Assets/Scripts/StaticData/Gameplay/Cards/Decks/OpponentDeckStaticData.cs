using System.Collections.Generic;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Decks
{
  [CreateAssetMenu(fileName = "OpponentDeckStaticData", menuName = "Static Data / Cards / Decks / Create Opponent Deck", order = 52)]
  public class OpponentDeckStaticData : ScriptableObject
  {
    public string LevelKey;
    public List<CardStaticData> Cards;
  }
}
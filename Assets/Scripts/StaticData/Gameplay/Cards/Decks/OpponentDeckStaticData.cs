using UnityEngine;

namespace StaticData.Gameplay.Cards.Decks
{
  [CreateAssetMenu(fileName = "OpponentDeckStaticData", menuName = "Static Data / Cards / Decks / Create Opponent Deck", order = 52)]
  public class OpponentDeckStaticData : DeckStaticData
  {
    public string LevelKey;
   
  }
}
using System.Collections.Generic;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Decks
{
    [CreateAssetMenu(fileName = "DeckStaticData", menuName = "Static Data / Cards / Decks / Create Deck", order = 52)]
    public class DeckStaticData : ScriptableObject
    { 
        public List<CardStaticData> Cards;
    }
}

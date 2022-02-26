using UnityEngine;

namespace StaticData.Gameplay.Player
{
  [CreateAssetMenu(fileName = "PlayerGoldStaticData", menuName = "Static Data/Player/Create Player Gold Data", order = 52)]
  public class PlayerGoldStaticData : ScriptableObject
  {
    public int MinValue = 20;
    public int MaxValue = 100;
  }
}
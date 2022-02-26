using System;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Table;
using Services.Assets;
using Services.Cards.Decks.Player;
using Services.Cards.Hand;
using Services.Hero;
using Services.StaticData;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public class CardFactory : ICardFactory
  {
    private readonly Card prefab;
    private readonly IStaticDataService staticData;
    private readonly IPlayerGold playerGold;
    private readonly IPlayerDeck playerDeck;
    private readonly IPlayerHand playerHand;
    private readonly IAssetProvider assets;
    private Field field;

    public CardFactory(IAssetProvider assetProvider, Card cardPrefab, IStaticDataService staticDataService, IPlayerGold playerGold, IPlayerDeck playerDeck, IPlayerHand playerHand)
    {
      assets = assetProvider;
      prefab = cardPrefab;
      staticData = staticDataService;
      this.playerGold = playerGold;
      this.playerDeck = playerDeck;
      this.playerHand = playerHand;
    }
    
    public Card CreateCard(Transform transform, CardStaticData data, bool isPlayer)
    {
      Card card = assets.Instantiate(prefab, transform);
      card.Construct(data, CreateStrategy(data.ActionType));
      return card;
    }

    public Card RecreateCard(Card pooledCard, CardStaticData data, bool isPlayer)
    {
      pooledCard.Construct(data, CreateStrategy(data.ActionType));
      return pooledCard;
    }

    public Card SpawnPropsCard( Transform parent, bool isPlayer)
    {
      return assets.Instantiate(prefab, parent);
    }

    public void SetCurrentField(Field field)
    {
      this.field = field;
    }

    private CardUseStrategy CreateStrategy(PlayingActionType actionType)
    {
      switch (actionType)
      {
        case PlayingActionType.GoldSteal:
          return new GetGoldStrategy(staticData.ForStrategy(actionType), playerGold);
        case PlayingActionType.CancelOpponentProperty:
          return new CancelPropertyStrategy(staticData.ForStrategy(actionType), field, Vector2Int.down);
        case PlayingActionType.GetGold:
          return new GetGoldStrategy(staticData.ForStrategy(actionType), playerGold);
        case PlayingActionType.BlockPlayerCell:
          return new BlockPlayerCellStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.TakeAdditionalCard:
          return new TakeAdditionalCardStrategy(staticData.ForStrategy(actionType), playerDeck);
        case PlayingActionType.InvertProperty:
          return new InvertPropertyStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.SaveHand:
          return new SaveHandStrategy(staticData.ForStrategy(actionType), playerHand);
        case PlayingActionType.BlockNearestActions:
          return new BlockNearestActionsStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.OpponentShuffle:
          return new OpponentShuffleStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.PlayerShuffle:
          return new PlayerShuffleStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.DefFromBlocking:
          return new DefFromBlockingStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.MultiplierProperty:
          return new MultiplierPropertyStrategy(staticData.ForStrategy(actionType), field);
        case PlayingActionType.CancelPlayerProperty:
          return new CancelPropertyStrategy(staticData.ForStrategy(actionType), field, Vector2Int.up);
        default:
          throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
      }
    }
  }
}
using System;
using Gameplay.Table;
using GameStates.States.Interfaces;
using SceneLoading;
using Services.Cards.Decks.GameOpponent;
using Services.Cards.Decks.Player;
using Services.Factories.GameFactories;
using Services.FieldCreate;
using Services.Random;
using Services.StaticData;
using Services.UI.Factory;
using UnityEngine;


namespace GameStates.States
{
  public class LoadGameLevelState : IPayloadedState<string>
  {
    private readonly ISceneLoader sceneLoader;
    private readonly IGameStateMachine gameStateMachine;
    private readonly IGameFactory gameFactory;
    private readonly IUIFactory uiFactory;
    private readonly IStaticDataService staticData;
    private readonly IOpponentDeck opponentDeck;
    private readonly IPlayerDeck playerDeck;
    private readonly IRandomService randomService;

    private string lastPayload;

    public LoadGameLevelState(ISceneLoader sceneLoader, 
      IGameStateMachine gameStateMachine, 
      IGameFactory gameFactory, 
      IUIFactory uiFactory, 
      IStaticDataService staticData,
      IOpponentDeck opponentDeck,
      IPlayerDeck playerDeck,
      IRandomService randomService)
    {
      this.sceneLoader = sceneLoader;
      this.gameStateMachine = gameStateMachine;
      this.gameFactory = gameFactory;
      this.uiFactory = uiFactory;
      this.staticData = staticData;
      this.opponentDeck = opponentDeck;
      this.playerDeck = playerDeck;
      this.randomService = randomService;
    }

    public void Enter(string payload)
    {
      lastPayload = payload;
      sceneLoader.Load(payload, OnLoaded);
      InitDecks();
      UpdateRandomService();
    }

    public void Exit() { }

    private void OnLoaded()
    {
      InitGameWorld();
      gameStateMachine.Enter<GameLoopState>();
    }

    private void InitGameWorld()
    {
      InitUIRoot();

      GameObject hero = gameFactory.CreateHero();
      GameObject hud = CreateHud(hero, uiFactory.UIRoot);
      Camera camera = Camera.main;
      SetCameraToHud(hud, camera);
    }

    private void UpdateRandomService()
    {
      randomService.UpdateSeed(DateTime.UtcNow.Millisecond);
    }

    private void InitDecks()
    {
      opponentDeck.UpdateDeck(staticData.ForOpponent(lastPayload));
      playerDeck.UpdateDeck(staticData.ForPlayer());
    }

    private GameObject CreateHud(GameObject hero, Transform uiRoot) => 
      gameFactory.CreateHud(hero, uiRoot);

    private void InitUIRoot() => 
      uiFactory.CreateUIRoot();

    private void SetCameraToHud(GameObject hud, Camera camera) => 
      hud.GetComponent<Canvas>().worldCamera = camera;
  }
}
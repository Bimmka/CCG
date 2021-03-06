using Gameplay.Cards.CardsElement.Base;
using Gameplay.Table;
using GameStates.States.Interfaces;
using SceneLoading;
using Services;
using Services.Assets;
using Services.Audio;
using Services.Cards.Decks.GameOpponent;
using Services.Cards.Decks.Player;
using Services.Cards.Hand;
using Services.Cards.Spawners;
using Services.Factories.GameFactories;
using Services.FieldCreate;
using Services.Hero;
using Services.Progress;
using Services.Random;
using Services.StaticData;
using Services.UI.Factory;
using Services.UI.Windows;
using UnityEngine.Audio;

namespace GameStates.States
{
  public class BootstrapState : IState
  {
    private readonly ISceneLoader sceneLoader;
    private readonly IGameStateMachine gameStateMachine;
    private readonly AllServices services;

    public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ref AllServices services,
      ICoroutineRunner coroutineRunner, Card cardPrefab, AudioMixer mixer, CardProps propsPrefab)
    {
      this.gameStateMachine = gameStateMachine;
      this.sceneLoader = sceneLoader;
      this.services = services;
      RegisterServices(coroutineRunner, cardPrefab, mixer, propsPrefab);
    }

    public void Enter()
    {
     
    }

    public void Exit()
    {
      
    }

    private void RegisterServices(ICoroutineRunner coroutineRunner, Card cardPrefab, AudioMixer mixer,
      CardProps propsPrefab)
    {
      RegisterStateMachine();
      RegisterRandom();
      RegisterStaticDataService();
      RegisterProgress();
      RegisterAssets();
      RegisterPlayerGold();
      RegisterPlayerTurn();
      RegisterAudioSettings(mixer);
      RegisterAudioService();
      RegisterUIFactory();
      RegisterWindowsService();
      RegisterGameFactory();
      RegisterFieldCreateService();
      RegisterPlayerDeck();
      RegisterOpponentDeck();
      RegisterPlayerHand();
      RegisterCardFactory(cardPrefab, propsPrefab, coroutineRunner);
      RegisterCardSpawner();
    }

    private void RegisterGameFactory()
    {
      services.RegisterSingle<IGameFactory>(
        new GameFactory(
        services.Single<IAssetProvider>(), 
        services.Single<IStaticDataService>(),
        services.Single<IWindowsService>(), 
        services.Single<IPlayerGold>()
        ));
    }

    private void RegisterStateMachine() => 
      services.RegisterSingle(gameStateMachine);


    private void RegisterAssets()
    {
      IAssetProvider provider = new AssetProvider();
      services.RegisterSingle(provider);
    }

    private void RegisterStaticDataService()
    {
      IStaticDataService staticData = new StaticDataService();
      staticData.Load();
      services.RegisterSingle(staticData);
    }

    private void RegisterProgress() => 
      services.RegisterSingle(new PersistentProgressService());

    private void RegisterRandom() => 
      services.RegisterSingle(new RandomService());

    private void RegisterUIFactory() =>
      services.RegisterSingle(new UIFactory(
        services.Single<IGameStateMachine>(),
        services.Single<IAssetProvider>(),
        services.Single<IStaticDataService>(), 
        services.Single<IPlayerGold>(),
        services.Single<IPlayerTurns>(),
        services.Single<IAudioServiceSettings>()));

    private void RegisterWindowsService() => 
      services.RegisterSingle(new WindowsService(services.Single<IUIFactory>()));


    private void RegisterFieldCreateService()
    {
      services.RegisterSingle(new FieldCreateService(
        services.Single<IAssetProvider>(), 
        services.Single<IStaticDataService>().ForFieldCreate()));  
    }

    private void RegisterPlayerDeck() => 
      services.RegisterSingle(new PlayerDeck(services.Single<IRandomService>()));

    private void RegisterOpponentDeck() => 
      services.RegisterSingle(new OpponentDeck(services.Single<IRandomService>()));

    private void RegisterPlayerGold()
    {
      services.RegisterSingle(new PlayerGold());
    }

    private void RegisterCardFactory(Card prefab, CardProps propsPrefab, ICoroutineRunner coroutineRunner) => 
      services.RegisterSingle(new CardFactory(
        services.Single<IAssetProvider>(),
        prefab,
        propsPrefab,
        services.Single<IStaticDataService>(),
        services.Single<IPlayerGold>(),
        services.Single<IPlayerDeck>(),
        services.Single<IPlayerHand>(),
        coroutineRunner,
        services.Single<IRandomService>(),
        services.Single<IAudioService>()));

    private void RegisterCardSpawner() => 
      services.RegisterSingle(new CardSpawnerService(services.Single<ICardFactory>()));

    private void RegisterPlayerHand() => 
      services.RegisterSingle(new PlayerHand());
    
    private void RegisterPlayerTurn() => 
      services.RegisterSingle(new PlayerTurns());

    private void RegisterAudioSettings(AudioMixer mixer) => 
      services.RegisterSingle(new AudioServiceSettings(mixer));

    private void RegisterAudioService() => 
      services.RegisterSingle(new AudioService(services.Single<IAudioServiceSettings>(), services.Single<IStaticDataService>()));
  }
}
using GameStates.States.Interfaces;
using SceneLoading;
using Services.Factories.GameFactories;
using Services.FieldCreate;
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
    private readonly IFieldCreateService fieldCreateService;

    public LoadGameLevelState(ISceneLoader sceneLoader, 
      IGameStateMachine gameStateMachine, 
      IGameFactory gameFactory, 
      IUIFactory uiFactory, 
      IStaticDataService staticData,
      IFieldCreateService fieldCreateService)
    {
      this.sceneLoader = sceneLoader;
      this.gameStateMachine = gameStateMachine;
      this.gameFactory = gameFactory;
      this.uiFactory = uiFactory;
      this.staticData = staticData;
      this.fieldCreateService = fieldCreateService;
    }

    public void Enter(string payload)
    {
      sceneLoader.Load(payload, OnLoaded);
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

      InitGameField();
    }

    private void InitGameField()
    {
      fieldCreateService.CreateField();
    }

    private GameObject CreateHud(GameObject hero, Transform uiRoot) => 
      gameFactory.CreateHud(hero, uiRoot);

    private void InitUIRoot() => 
      uiFactory.CreateUIRoot();
    
    private void SetCameraToHud(GameObject hud, Camera camera) => 
      hud.GetComponent<Canvas>().worldCamera = camera;
  }
}
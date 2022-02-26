using System;
using Gameplay.Cards.Decks;
using Gameplay.Cards.Hand;
using Gameplay.Cards.Spawners;
using Gameplay.Clicks;
using Gameplay.GameMachine.States;
using Gameplay.GameplayActionPipeline;
using Gameplay.Table;
using Services.FieldCreate;
using Services.Hero;
using UI.Windows.PlayerHand;
using UnityEngine;
using Zenject;

namespace Gameplay.GameMachine
{
  public class GameplayStateMachine : MonoBehaviour
  {
    [SerializeField] private Field field;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private GameplayPlayerDeck playerDeck;
    [SerializeField] private GameplayPlayerHand playerHand;
    [SerializeField] private PlayerHandWindow playerHandWindow;
    [SerializeField] private PlayerClickHandler clickHandler;
    [SerializeField] private ActionPipeline actionPipeline;
    
    private IFieldCreateService fieldCreateService;

    private StateMachine stateMachine;
    private IPlayerGold playerGold;

    public PrepareGameState PrepareGameStateState { get; private set; }
    public PlayerStartTurn PlayerStartTurnState { get; private set; }
    public PlayerTurn PlayerTurnState { get; private set; }
    public PlayerEndTurn PlayerEndTurnState { get; private set; }
    public GameEnd GameEndState { get; private set; }

    [Inject]
    private void Construct(IFieldCreateService fieldCreateService, IPlayerGold playerGold)
    {
      this.fieldCreateService = fieldCreateService;
      this.playerGold = playerGold;
      this.playerGold.Ended += OnGoldEnded;
    }

    private void Awake()
    {
      playerHandWindow.EndTurnClicked += OnTurnEndClicked;
      actionPipeline.Ended += OnActionsEnd;
    }

    private void OnDestroy()
    {
      playerHandWindow.EndTurnClicked -= OnTurnEndClicked;
      actionPipeline.Ended -= OnActionsEnd;
      playerGold.Ended -= OnGoldEnded;
      playerGold.Reset();
    }

    private void Start()
    {
      CreateStateMachine();
      CreateStates();
      InitStateMachine();
    }

    private void CreateStateMachine()
    {
      stateMachine = new StateMachine();
    }

    private void CreateStates()
    {
      PrepareGameStateState = new PrepareGameState(this, stateMachine);
      PlayerStartTurnState = new PlayerStartTurn(this, stateMachine, playerHand, clickHandler);
      PlayerTurnState = new PlayerTurn(this, stateMachine);
      PlayerEndTurnState = new PlayerEndTurn(this, stateMachine, clickHandler, actionPipeline, field);
      GameEndState = new GameEnd(this, stateMachine);
    }

    private void InitStateMachine()
    {
      stateMachine.Initialize(PrepareGameStateState);
    }

    public void CreateField() => 
      fieldCreateService.CreateField(field);

    public void SpawnFirstOpponentsCard() => 
      cardSpawner.FirstOpponentSpawn();

    public void SpawnPlayerDeckProps() => 
      playerDeck.Init();

    private void OnTurnEndClicked()
    {
      if (stateMachine.State == PlayerTurnState)
        stateMachine.ChangeState(PlayerEndTurnState);
    }

    private void OnActionsEnd()
    {
      if (true)
        stateMachine.ChangeState(PlayerStartTurnState);
    }

    private void OnGoldEnded()
    {
      
    }
  }
}
using System;
using Gameplay.Cards.CardsElement.Base;
using GameStates;
using GameStates.States;
using SceneLoading;
using Services;
using UnityEngine;

namespace Bootstrapp
{
  public class GameBootstrapp : MonoBehaviour, ICoroutineRunner
  {

    private Game game;

    private void Start()
    {
      game.StateMachine.Enter<LoadProgressState>();
    }

    public void Init(ref AllServices services,  LoadingCurtain loadingCurtain, Card cardPrefab)
    {
      game = new Game(this, loadingCurtain, ref services, cardPrefab);
      game.StateMachine.Enter<BootstrapState>();
    }

  }
}

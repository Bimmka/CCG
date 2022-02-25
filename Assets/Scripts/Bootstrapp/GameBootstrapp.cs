using System;
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

    public void Init(ref AllServices services,  LoadingCurtain loadingCurtain)
    {
      game = new Game(this, loadingCurtain, ref services);
      game.StateMachine.Enter<BootstrapState>();
    }

  }
}

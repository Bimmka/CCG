using Gameplay.Cards.CardsElement.Base;
using GameStates;
using GameStates.States;
using SceneLoading;
using Services;
using Services.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace Bootstrapp
{
  public class GameBootstrapp : MonoBehaviour, ICoroutineRunner
  {
    private Game game;

    private IAudioServiceSettings audioSettings;

    private void Start()
    {
      audioSettings.Load();
      game.StateMachine.Enter<LoadProgressState>();
    }

    public void Init(ref AllServices services, LoadingCurtain loadingCurtain, Card cardPrefab, AudioMixer mixer)
    {
      game = new Game(this, loadingCurtain, ref services, cardPrefab, mixer);
      game.StateMachine.Enter<BootstrapState>();
      audioSettings = services.Single<IAudioServiceSettings>();
    }

  }
}

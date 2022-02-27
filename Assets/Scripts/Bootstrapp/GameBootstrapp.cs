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
    private IAudioService audioService;

    private void Start()
    {
      audioSettings.Load();
      audioService.StartPlayMenuTheme();
      game.StateMachine.Enter<LoadProgressState>();
    }

    public void Init(ref AllServices services, LoadingCurtain loadingCurtain, Card cardPrefab, AudioMixer mixer,
      CardProps propsPrefab)
    {
      game = new Game(this, loadingCurtain, ref services, cardPrefab, mixer, propsPrefab);
      game.StateMachine.Enter<BootstrapState>();
      audioSettings = services.Single<IAudioServiceSettings>();
      audioService = services.Single<IAudioService>();
    }

  }
}

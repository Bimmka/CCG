using Gameplay.Cards.CardsElement.Base;
using SceneLoading;
using Services;
using UnityEngine.Audio;

namespace GameStates
{
  public class Game
  {
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, ref AllServices services, Card cardPrefab,
      AudioMixer mixer)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner,curtain), ref services, coroutineRunner, cardPrefab, mixer);
    }
  }
}
using System.Collections;
using ConstantsValue;
using Gameplay.Cards.CardsElement.Base;
using GameStates;
using SceneLoading;
using Services;
using Services.Assets;
using Services.Cards.Decks.GameOpponent;
using Services.Cards.Decks.Player;
using Services.Cards.Spawners;
using Services.FieldCreate;
using Services.Progress;
using Services.Random;
using Services.UI.Factory;
using Services.UI.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Bootstrapp
{
    public class ProjectBootstrapper : MonoInstaller
    {
      [SerializeField] private GameBootstrapp gameBootstrapp;
      [SerializeField] private LoadingCurtain curtain;
      [SerializeField] private Card cardPrefab;
        

        private LoadingCurtain spawnedCurtain;
        private GameBootstrapp spawnedGameBootstrapp;
        private AllServices allServices;

        public override void InstallBindings()
        {
          InstantiateComponents();
          BindComponents();
        }

        private void BindComponents()
        {
          BindProgressService();
          BindGameStateMachine();
          BindUIFactory();
          BindWindowsService();
          BindRandomService();
          BindAssetsService();
          BindFieldCreatingService();
          BindPlayerDeck();
          BindOpponentDeck();
          BindCardSpawner();
        }

       
        private void InstantiateComponents()
        {
          InitServices();
          InstantiateCurtain();
          InstantiateBootstrapper();
        }
        

        private void InitServices() => 
          allServices = new AllServices();

        private void InstantiateCurtain() => 
          spawnedCurtain = Instantiate(curtain);

        private void InstantiateBootstrapper()
        {
          spawnedGameBootstrapp = Instantiate(gameBootstrapp, transform);
          spawnedGameBootstrapp.Init(ref allServices, spawnedCurtain, cardPrefab);
        }
        
        private void BindProgressService() => 
          Container.Bind<IPersistentProgressService>().To<IPersistentProgressService>().FromInstance(allServices.Single<IPersistentProgressService>()).AsCached();

        private void BindGameStateMachine() => 
          Container.Bind<IGameStateMachine>().To<IGameStateMachine>().FromInstance(allServices.Single<IGameStateMachine>()).AsCached();

        private void BindUIFactory() => 
          Container.Bind<IUIFactory>().To<IUIFactory>().FromInstance(allServices.Single<IUIFactory>()).AsCached();

        private void BindWindowsService() => 
          Container.Bind<IWindowsService>().To<IWindowsService>().FromInstance(allServices.Single<IWindowsService>()).AsCached();

        private void BindRandomService() => 
          Container.Bind<IRandomService>().To<IRandomService>().FromInstance(allServices.Single<IRandomService>()).AsCached();
        
        private void BindAssetsService() => 
          Container.Bind<IAssetProvider>().To<IAssetProvider>().FromInstance(allServices.Single<IAssetProvider>()).AsCached();
        
        private void BindFieldCreatingService() => 
          Container.Bind<IFieldCreateService>().To<IFieldCreateService>().FromInstance(allServices.Single<IFieldCreateService>()).AsCached();
        
        private void BindPlayerDeck() => 
          Container.Bind<IPlayerDeck>().To<IPlayerDeck>().FromInstance(allServices.Single<IPlayerDeck>()).AsCached();
        private void BindOpponentDeck() => 
          Container.Bind<IOpponentDeck>().To<IOpponentDeck>().FromInstance(allServices.Single<IOpponentDeck>()).AsCached(); 
        private void BindCardSpawner() => 
          Container.Bind<ICardSpawner>().To<ICardSpawner>().FromInstance(allServices.Single<ICardSpawner>()).AsCached();

    }
}

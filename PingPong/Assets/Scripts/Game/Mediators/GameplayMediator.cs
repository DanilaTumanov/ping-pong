using System;
using Game.Gameplay;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using Game.Models;
using Game.Services;
using Game.Services.ConfigService;
using Game.Services.InputService;
using Game.Services.UserDataService;
using Game.Signals;
using Photon.Pun;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Mediators
{
    
    /// <summary>
    /// Медиатор геймплея, определяет глобальную логику отображения после аута,
    /// ожидает подключения оппонента для запуска игры, создает игроков и мячи
    /// </summary>
    public class GameplayMediator : Mediator
    {

        [Inject]
        public GameplayView View { get; set; }
        
        [Inject]
        public IConfigService ConfigService { get; set; }
        
        [Inject]
        public INetworkService NetworkService { get; set; }
        
        [Inject]
        public INetworkModel NetworkModel { get; set; }
        
        [Inject]
        public OutSignal OutSignal { get; set; }
        
        
        

        public override void OnRegister()
        {
            base.OnRegister();

            OutSignal.AddListener(OutHandler);
            
            NetworkModel.Opponent.OnChanged += OnNewOpponentHandler;
        }

        private Ball GetRandomBall()
        {
            return NetworkService.Instantiate<Ball>(
                ConfigService.Config.ballsPrefabsResourceFolder + "/" 
              + ConfigService.Config.ballsPrefabs[
                    Random.Range(0, ConfigService.Config.ballsPrefabs.Length)
                ].name,
                Vector3.zero,
                Quaternion.identity
            );
        }

        private void OutHandler()
        {
            if (NetworkService.IsMasterClient)
            {
                Debug.Log("New ball");
                View.BallInPlay(GetRandomBall());
            }
        }

        private void OnNewOpponentHandler(Photon.Realtime.Player oldOpponent, Photon.Realtime.Player newOpponent)
        {
            var player = NetworkService.Instantiate<Player>(
                ConfigService.Config.playerPrefabResourceFolder + "/" + ConfigService.Config.playerPrefab.name,
                Vector3.zero,
                Quaternion.identity
            );
 
            View.SetPlayer(player, NetworkService.IsMasterClient);
            
            if(NetworkService.IsMasterClient)
                View.BallInPlay(GetRandomBall());
        }
    }
}

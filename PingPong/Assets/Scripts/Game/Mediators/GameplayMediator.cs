using System;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using Game.Services.ConfigService;
using Game.Services.InputService;
using Game.Views;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Mediators
{
    public class GameplayMediator : Mediator
    {

        [Inject]
        public GameplayView View { get; set; }
        
        [Inject]
        public IConfigService ConfigService { get; set; }


        public override void OnRegister()
        {
            base.OnRegister();

            View.OnOut += OutHandler;
            View.BallInPlay(GetRandomBall());
        }

        private Ball GetRandomBall()
        {
            return Instantiate(
                ConfigService.Config.ballsPrefabs[
                    Random.Range(0, ConfigService.Config.ballsPrefabs.Length)
                ]
            );
        }

        private void OutHandler()
        {
            View.BallInPlay(GetRandomBall());
        }
    }
}

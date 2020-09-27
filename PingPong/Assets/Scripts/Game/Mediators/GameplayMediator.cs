using System;
using Game.Gameplay;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using Game.Models;
using Game.Services.ConfigService;
using Game.Services.InputService;
using Game.Services.UserDataService;
using Game.Signals;
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
        
        [Inject]
        public OutSignal OutSignal { get; set; }

        [Inject]
        public HitSignal HitSignal { get; set; }
        

        public override void OnRegister()
        {
            base.OnRegister();

            View.OnOut += OutHandler;
            View.OnHit += HitHandler;
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
            OutSignal.Dispatch();
            View.BallInPlay(GetRandomBall());
        }

        private void HitHandler()
        {
            HitSignal.Dispatch();
        }
    }
}

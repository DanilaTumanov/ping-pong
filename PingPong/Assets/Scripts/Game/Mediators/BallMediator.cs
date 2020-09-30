using Game.Gameplay.GameEntities.Balls;
using Game.Services;
using Game.Signals;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Mediators
{
    public class BallMediator : Mediator
    {
        
        [Inject]
        public BallView View { get; set; }

        [Inject]
        public INetworkService NetworkService { get; set; }
        
        [Inject]
        public OutSignal OutSignal { get; set; }

        [Inject]
        public HitSignal HitSignal { get; set; }
        
        
        public override void OnRegister()
        {
            base.OnRegister();

            View.OnBallHit += HitHandler;
            View.OnBallOut += OutHandler;
            
            Debug.Log("Ball mediator register");
        }

        private void HitHandler()
        {
            HitSignal.Dispatch();
        }

        private void OutHandler()
        {
            OutSignal.Dispatch();
            Debug.Log("Out Handler");

            if (NetworkService.IsMasterClient)
            {
                Debug.Log("Destroy ball");
                NetworkService.Destroy(View.BallPhoton);
            }
        }
    }
}

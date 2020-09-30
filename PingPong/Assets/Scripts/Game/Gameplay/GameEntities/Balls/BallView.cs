using System;
using Photon.Pun;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Balls
{
    public class BallView : View
    {

        [SerializeField] private Ball _ball;
        [SerializeField] private BallPhoton _ballPhoton;

        public BallPhoton BallPhoton => _ballPhoton;
        
        public event Action OnBallOut;
        public event Action OnBallHit;
        
        protected override void Awake()
        {
            base.Awake();
            
            if (_ball == null)
                _ball = GetComponent<Ball>();
            
            if (_ballPhoton == null)
                _ballPhoton = GetComponent<BallPhoton>();

            _ballPhoton.OnSyncOut += SyncOutHandler;
            _ballPhoton.OnSyncHit += SyncHitHandler;

            _ball.OnBallHit += HitHandler;
            _ball.OnBallOut += OutHandler;
        }
        
        
        public void OutHandler()
        {
            BallPhoton.RPC(nameof(BallPhoton.SyncOut), RpcTarget.All);
        }
        
        public virtual void HitHandler()
        {
            BallPhoton.RPC(nameof(BallPhoton.SyncHit), RpcTarget.All);
        }
        
        private void SyncOutHandler()
        {
            OnBallOut?.Invoke();
        }
        
        private void SyncHitHandler()
        {
            OnBallHit?.Invoke();
        }
    }
}

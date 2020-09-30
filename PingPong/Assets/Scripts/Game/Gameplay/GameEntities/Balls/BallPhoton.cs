using System;
using Photon.Pun;

namespace Game.Gameplay.GameEntities.Balls
{
    public class BallPhoton : PhotonView
    {
        
        public event Action OnSyncOut;
        public event Action OnSyncHit;

        [PunRPC]
        public void SyncOut()
        {
            OnSyncOut?.Invoke();
        }
        
        [PunRPC]
        public void SyncHit()
        {
            OnSyncHit?.Invoke();
        }
        
    }
}

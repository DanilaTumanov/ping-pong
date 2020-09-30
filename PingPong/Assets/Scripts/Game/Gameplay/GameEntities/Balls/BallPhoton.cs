using System;
using Photon.Pun;

namespace Game.Gameplay.GameEntities.Balls
{
    
    /// <summary>
    /// Класс для сетевой синхронизации мяча. Содержит RPC методы
    /// для синхронизации событий удара и аута (они происходят только на мастер-клиенте),
    /// поэтому нужно пробросить эти события на все клиенты
    /// </summary>
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

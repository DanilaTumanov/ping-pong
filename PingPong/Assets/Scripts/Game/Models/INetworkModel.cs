using System;
using Photon.Realtime;

namespace Game.Models
{
    
    /// <summary>
    /// Модель с информацией о сетевом подключении
    /// </summary>
    public interface INetworkModel
    {
        
        ContextProperty<string> InvitationCode { get; }
        
        ContextProperty<Player> Opponent { get; }

    }
}

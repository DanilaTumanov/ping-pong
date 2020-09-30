using System;
using Photon.Realtime;

namespace Game.Models
{
    public interface INetworkModel
    {
        
        ContextProperty<string> InvitationCode { get; }
        
        ContextProperty<Player> Opponent { get; }

    }
}

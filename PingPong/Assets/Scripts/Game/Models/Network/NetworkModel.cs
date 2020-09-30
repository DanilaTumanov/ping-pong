using System.Collections;
using System.Collections.Generic;
using Game.Models;
using Photon.Realtime;
using UnityEngine;

public class NetworkModel : INetworkModel
{
    
    public ContextProperty<string> InvitationCode { get; } = new ContextProperty<string>();
    public ContextProperty<Player> Opponent { get; } = new ContextProperty<Player>();
}

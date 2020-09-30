using System.Collections;
using System.Collections.Generic;
using Game.Models;
using Game.Services.NetworkService;
using Game.Services.RuntimeService;
using Game.Services.UserDataService;
using Photon.Realtime;
using UnityEngine;

public class NetworkModel : Model, INetworkModel
{
    
    public ContextProperty<string> InvitationCode { get; } = new ContextProperty<string>();
    public ContextProperty<Player> Opponent { get; } = new ContextProperty<Player>();

    public NetworkModel(IUserDataService userDataService, IRuntimeService runtimeService) : base(userDataService, runtimeService)
    {
    }
}

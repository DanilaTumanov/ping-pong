using System;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Game.Services
{
    public interface INetworkService
    {

        Player LocalPlayer { get; }
        bool IsMasterClient { get; }
        
        Task CreateRoomAsync(string code);
        Task<Player> JoinGameAsync(string code);
        Task LeaveGame();

        T Instantiate<T>(string prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour;
        void Destroy(PhotonView networkObject);
        
        event Action<Player> OnPlayerConnected;
        event Action<Player> OnPlayerDisconnected;

    }
}

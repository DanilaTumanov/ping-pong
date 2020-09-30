using System;
using System.Threading.Tasks;
using Photon.Realtime;

namespace Game.Services
{
    public interface INetworkService
    {

        Player LocalPlayer { get; }
        
        Task CreateRoomAsync(string code);
        Task<Player> JoinGameAsync(string code);
        Task LeaveGame();

        event Action<Player> OnPlayerConnected;
        event Action<Player> OnPlayerDisconnected;

    }
}

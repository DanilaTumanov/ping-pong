using System;
using System.Linq;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Game.Services.NetworkService
{
    public class PhotonCallbacksClient : MonoBehaviourPunCallbacks
    {
        
        private TaskCompletionSource<bool> _connection;
        private TaskCompletionSource<bool> _createRoom;
        private TaskCompletionSource<Player> _joinRoom;
        private TaskCompletionSource<bool> _leaveRoom;


        public event Action<Player> OnPlayerConnected;
        public event Action<Player> OnPlayerDisconnected;
        
        public async Task ConnectAsync()
        {
            _connection = new TaskCompletionSource<bool>();
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.ConnectUsingSettings();
            await _connection.Task;
        }
        
        public override void OnConnectedToMaster()
        {
            if (!PhotonNetwork.InLobby)
                PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            _connection?.SetResult(true);
            _connection = null;
        }


        public async Task CreateRoomAsync(string name)
        {
            _createRoom = new TaskCompletionSource<bool>();

            if (!PhotonNetwork.IsConnected)
            {
                _createRoom.SetException(new Exception("Create room fail: Photon is not connected"));
            }
            
            var roomOptions = new RoomOptions
            {
                MaxPlayers = 2
            };

            PhotonNetwork.JoinOrCreateRoom(name, roomOptions, TypedLobby.Default);

            await _createRoom.Task;
        }
        
        
        public override void OnCreatedRoom()
        {
            _createRoom?.SetResult(true);
            _createRoom = null;
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            _createRoom?.SetException(new Exception(message));
            _createRoom = null;
        }


        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            OnPlayerConnected?.Invoke(newPlayer);
        }


        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            OnPlayerDisconnected?.Invoke(otherPlayer);
        }



        public async Task<Player> JoinRoomAsync(string code)
        {
            await LeaveRoomAsync();
            await ConnectAsync();
            
            _joinRoom = new TaskCompletionSource<Player>();
            PhotonNetwork.JoinRoom(code);
            return await _joinRoom.Task;
        }


        public override void OnJoinedRoom()
        {
            _joinRoom?.SetResult(PhotonNetwork.CurrentRoom.Players.First().Value);
            _joinRoom = null;
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            _joinRoom?.SetException(new Exception(message));
            _joinRoom = null;
        }
        
        
        
        public async Task LeaveRoomAsync()
        {
            _leaveRoom = new TaskCompletionSource<bool>();
            PhotonNetwork.LeaveRoom();
            await _leaveRoom.Task;
        }

        public override void OnLeftRoom()
        {
            _leaveRoom?.SetResult(true);
            _leaveRoom = null;
        }
    }
}

using System;
using System.Collections;
using System.Threading.Tasks;
using Game.Services.RuntimeService;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Game.Services.NetworkService
{
    
    /// <summary>
    /// Сервис сетевого взаимодействия Photon
    /// </summary>
    public class PhotonService : INetworkService
    {
        private const int RETRY_MILLISECONDS = 5000;


        private readonly IRuntimeService _runtimeService;
        private readonly PhotonCallbacksClient _photonClient;
        
        private Task _connectionTask;


        public Player LocalPlayer => PhotonNetwork.LocalPlayer;
        public bool IsMasterClient => PhotonNetwork.IsMasterClient;


        public event Action<Player> OnPlayerConnected;

        public event Action<Player> OnPlayerDisconnected;


        public PhotonService(IRuntimeService runtimeService)
        {
            _runtimeService = runtimeService;
            _photonClient = runtimeService.RegisterClient<PhotonCallbacksClient>();
            
            _photonClient.OnPlayerConnected += p => OnPlayerConnected?.Invoke(p);
            _photonClient.OnPlayerDisconnected += p => OnPlayerDisconnected?.Invoke(p);
            
            Connect();
        }


        private async Task Connect()
        {
            if (_connectionTask != null)
            {
                await _connectionTask;
                return;
            }
                
            
            try
            {
                _connectionTask = _photonClient.ConnectAsync();
                await _connectionTask;
                Debug.Log($"Photon connected");
            }
            catch (Exception e)
            {
                Debug.LogError($"Connection fail: {e}");
                await Task.Delay(RETRY_MILLISECONDS);
                await Connect();
            }
        }


        public async Task CreateRoomAsync(string code)
        {
            try
            {
                await Connect();
                await _photonClient.CreateRoomAsync(code);
                Debug.Log($"Room created: {code}");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public async Task<Player> JoinGameAsync(string code)
        {
            return await _photonClient.JoinRoomAsync(code);
        }


        public Task LeaveGame()
        {
            throw new System.NotImplementedException();
        }

        public T Instantiate<T>(string prefabPath, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            return PhotonNetwork.Instantiate(prefabPath, Vector3.zero, Quaternion.identity).GetComponent<T>();
        }

        public void Destroy(PhotonView networkObject)
        {
            PhotonNetwork.Destroy(networkObject);
        }
    }
}

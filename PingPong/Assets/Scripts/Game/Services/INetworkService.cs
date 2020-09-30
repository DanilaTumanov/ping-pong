using System;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Game.Services
{
    
    /// <summary>
    /// Сервис сетевого взаимодействия.
    /// </summary>
    public interface INetworkService
    {

        Player LocalPlayer { get; }
        bool IsMasterClient { get; }
        
        Task CreateRoomAsync(string code);
        Task<Player> JoinGameAsync(string code);
        Task LeaveGame();

        /// <summary>
        /// Создание сетевого объекта Photon
        /// </summary>
        /// <param name="prefab">Путь к префабу в папке Resources (так уж работает Photon)</param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <typeparam name="T">Тип компонента префаба, который вернется в после создания</typeparam>
        /// <returns></returns>
        T Instantiate<T>(string prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour;
        
        /// <summary>
        /// Удаление сетевого объекта Photon
        /// </summary>
        /// <param name="networkObject"></param>
        void Destroy(PhotonView networkObject);
        
        event Action<Player> OnPlayerConnected;
        event Action<Player> OnPlayerDisconnected;

    }
}

using System.Threading.Tasks;
using Game.Models;
using Game.Services;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    public class StartApp : Command
    {
        private readonly INetworkService _networkService;
        private readonly INetworkModel _networkModel;

        public StartApp(INetworkService networkService, INetworkModel networkModel)
        {
            _networkService = networkService;
            _networkModel = networkModel;
        }
        
        public override void Execute()
        {
            CreateGame(Random.Range(10000, 100000).ToString());
        }

        private async Task CreateGame(string code)
        {
            try
            {
                await _networkService.CreateRoomAsync(code);
                _networkModel.InvitationCode.Value = code;
                _networkService.OnPlayerConnected += p => _networkModel.Opponent.Value = p;
            }
            catch
            {
                // ignore
            }
        }
    }
}

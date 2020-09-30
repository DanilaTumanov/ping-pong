using System.Threading.Tasks;
using Game.Models;
using Game.Services;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    
    /// <summary>
    /// Команда обработки присоединения к игре
    /// </summary>
    public class JoinGameCommand : Command
    {
        private readonly INetworkService _networkService;
        private readonly INetworkModel _networkModel;

        [Inject]
        public string Code { get; set; }


        public JoinGameCommand(INetworkService networkService, INetworkModel networkModel)
        {
            _networkService = networkService;
            _networkModel = networkModel;
        }
        
        public override void Execute()
        {
            JoinGame(Code);
        }

        private async Task JoinGame(string code)
        {
            _networkModel.Opponent.Value = await _networkService.JoinGameAsync(Code);
        }
    }
}

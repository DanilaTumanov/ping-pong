using System.Threading.Tasks;
using Game.Models;
using Game.Services;
using Game.Services.ConfigService;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    
    /// <summary>
    /// Стартовая команда с бизнес-логикой запуска игры
    /// </summary>
    public class StartApp : Command
    {
        private readonly INetworkService _networkService;
        private readonly INetworkModel _networkModel;
        private readonly IConfigService _configService;

        public StartApp(INetworkService networkService, INetworkModel networkModel, IConfigService configService)
        {
            _networkService = networkService;
            _networkModel = networkModel;
            _configService = configService;
        }
        
        public override void Execute()
        {
            CreateGame(
                Random.Range(
                    _configService.Config.invitationCodesRange.x, 
                    _configService.Config.invitationCodesRange.y
                ).ToString()
            );
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

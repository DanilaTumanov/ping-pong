using System.Collections.Generic;
using System.Linq;
using Game.Services.ConfigService;
using Game.Services.RuntimeService;
using Game.Services.UserDataService;
using UnityEngine;

namespace Game.Models.Settings
{
    public class SettingsModel : Model, ISettingsModel
    {
        [Save] public ContextProperty<int> SelectedBackground { get; } = new ContextProperty<int>();
        public ContextProperty<List<Sprite>> BackgroundsList { get; } = new ContextProperty<List<Sprite>>();


        public SettingsModel(IConfigService configService, IUserDataService userDataService, IRuntimeService runtimeService) : base(userDataService, runtimeService)
        {
            BackgroundsList.Value = configService.Config.backgrounds.ToList();    
        }
    }
}

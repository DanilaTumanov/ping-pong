using Game.Models;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    public class SelectedBackgroundCommand : Command
    {
        private readonly ISettingsModel _settingsModel;

        [Inject]
        public int SelectedIndex { get; set; }


        public SelectedBackgroundCommand(ISettingsModel settingsModel)
        {
            _settingsModel = settingsModel;
        }
        
        
        public override void Execute()
        {
            _settingsModel.SelectedBackground.Value = SelectedIndex;
        }
    }
}

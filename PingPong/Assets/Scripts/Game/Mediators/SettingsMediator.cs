using Game.Models;
using Game.Services.ConfigService;
using Game.Signals;
using Game.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Mediators
{
    public class SettingsMediator : Mediator
    {
        
        [Inject]
        public SettingsView View { get; set; }

        [Inject]
        public ISettingsModel SettingsModel { get; set; }
        
        [Inject]
        public SelectedBackgroundSignal SelectedBackgroundSignal { get; set; }
        
        [Inject]
        public SettingsCloseButtonSignal SettingsCloseButtonSignal { get; set; }
        
        
        public override void OnRegister()
        {
            base.OnRegister();
            
            View.Hide();
            
            View.SetBackgroundsList(SettingsModel.BackgroundsList, SettingsModel.SelectedBackground);
            View.OnBackgroundSelected += BackgroundSelectedHandler;
            View.OnCloseButtonPressed += CloseButtonHandler;
        }

        private void CloseButtonHandler()
        {
            SettingsCloseButtonSignal.Dispatch();
        }

        private void BackgroundSelectedHandler(int selectedIndex)
        {
            SelectedBackgroundSignal.Dispatch(selectedIndex);
        }
    }
}

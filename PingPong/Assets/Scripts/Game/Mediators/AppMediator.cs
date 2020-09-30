using Game.Models;
using Game.Signals;
using Game.Views;
using Photon.Realtime;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    
    /// <summary>
    /// Медиатор корневого уровня приложения. Может переключать глобальные меню и игровой экран
    /// </summary>
    public class AppMediator : Mediator
    {
    
        [Inject]
        public AppView View { get; set; }
    
        [Inject]
        public INetworkModel NetworkModel { get; set; }
        
        [Inject]
        public SettingsOpenButtonSignal SettingsOpenButtonSignal { get; set; }

        [Inject]
        public SettingsCloseButtonSignal SettingsCloseButtonSignal { get; set; }

        
        public override void OnRegister()
        {
            base.OnRegister();

            NetworkModel.Opponent.OnChanged += OpponentChangeHandler;
            
            SettingsOpenButtonSignal.AddListener(SettingsOpenButtonHandler);
            SettingsCloseButtonSignal.AddListener(SettingsCloseButtonHandler);
        }

        private void OpponentChangeHandler(Player oldOpponent, Player newOpponent)
        {
            if (newOpponent != null)
            {
                View.StartGame();
            }
        }


        private void SettingsOpenButtonHandler()
        {
            View.ShowSettings();
        }
        
        private void SettingsCloseButtonHandler()
        {
            View.HideSettings();
        }
    }
}

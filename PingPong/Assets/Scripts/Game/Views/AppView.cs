using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Views
{
    
    /// <summary>
    /// Корневой элемент отображения игры, содержит апи для переключения вложенных окон
    /// </summary>
    public class AppView : View
    {

        [SerializeField] private StartMenuView _startMenuView;
        [SerializeField] private HudView _hudView;
        [SerializeField] private SettingsView _settingsView;


        public void StartGame()
        {
            _startMenuView.Hide();
            _hudView.Show();
        }

        public void StopGame()
        {
            _startMenuView.Show();
            _hudView.Hide();
        }


        public void ShowSettings()
        {
            _settingsView.Show();
        }

        public void HideSettings()
        {
            _settingsView.Hide();
        }

    }
}

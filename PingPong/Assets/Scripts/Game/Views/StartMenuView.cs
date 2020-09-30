using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class StartMenuView : CanvasView
    {

        [SerializeField] private Text _invitationCode;

        [SerializeField] private InputField _joinCode;

        [SerializeField] private Button _joinGame;
        
        [SerializeField] private Button _settingsButton;


        public event Action<string> OnJoinGamePressed;
        public event Action OnSettingsButtonPressed;
        

        protected override void Awake()
        {
            base.Awake();
            
            _joinGame.onClick.AddListener(JoinButtonHandler);
            _settingsButton.onClick.AddListener(SettingsButtonHandler);
        }

        public void SetInvitationCode(string code)
        {
            _invitationCode.text = code;
        }

        private void JoinButtonHandler()
        {
            OnJoinGamePressed?.Invoke(_joinCode.text);
        }

        private void SettingsButtonHandler()
        {
            OnSettingsButtonPressed?.Invoke();
        }
        
    }
}

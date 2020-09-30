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


        public event Action<string> OnJoinGamePressed;
        

        protected override void Awake()
        {
            base.Awake();
            
            _joinGame.onClick.AddListener(JoinButtonHandler);
        }

        public void SetInvitationCode(string code)
        {
            _invitationCode.text = code;
        }

        private void JoinButtonHandler()
        {
            OnJoinGamePressed?.Invoke(_joinCode.text);
        }
        
    }
}

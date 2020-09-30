using System;
using Game.Gameplay;
using Game.Services.InputService;
using Photon.Pun;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    public class PlayerMediator : Mediator
    {
    
        [Inject]
        public Player View { get; set; }
        
        [Inject]
        public IInputController _inputController { get; set; }


        private void Update()
        {
            if (_inputController.IsSwipe && View.PlayerPhoton.IsMine)
            {
                View.Move((PhotonNetwork.IsMasterClient ? 1 : -1) * _inputController.SwipeVector);
            }
        }
    }
}

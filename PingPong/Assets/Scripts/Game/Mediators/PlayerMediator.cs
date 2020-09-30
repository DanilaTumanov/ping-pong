using System;
using Game.Gameplay;
using Game.Services;
using Game.Services.InputService;
using Photon.Pun;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Mediators
{
    
    /// <summary>
    /// Медиатор игрока, отвечает за отображение игрока,
    /// реагирует на пользовательский ввод
    /// </summary>
    public class PlayerMediator : Mediator
    {
    
        [Inject]
        public Player View { get; set; }
        
        [Inject]
        public IInputController _inputController { get; set; }


        private Camera _cam;


        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            if (_inputController.IsSwipe && View.PlayerPhoton.IsMine)
            {
                View.Move((PhotonNetwork.IsMasterClient ? 1 : -1) * _cam.orthographicSize * 2 * _inputController.SwipeVector);
            }
        }
    }
}

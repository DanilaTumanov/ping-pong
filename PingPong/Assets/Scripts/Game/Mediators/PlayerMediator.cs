using System;
using Game.Services.InputService;
using Game.Views;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    public class PlayerMediator : Mediator
    {
    
        [Inject]
        public PlayerView View { get; set; }
        
        [Inject]
        public IInputController _inputController { get; set; }


        private void Update()
        {
            if (_inputController.IsSwipe)
            {
                View.Move(_inputController.SwipeVector);
            }
        }
    }
}

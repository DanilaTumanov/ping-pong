using System;
using Game.Gameplay;
using Game.Services.InputService;
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
            if (_inputController.IsSwipe)
            {
                View.Move(_inputController.SwipeVector);
            }
        }
    }
}

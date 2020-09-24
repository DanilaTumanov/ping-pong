using System;
using Game.Services.InputService;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Mediators
{
    public class GameplayMediator : Mediator
    {

        [Inject]
        public GameplayView View { get; set; }

    }
}

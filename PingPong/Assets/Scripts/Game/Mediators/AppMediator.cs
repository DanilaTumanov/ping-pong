using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class AppMediator : Mediator
{
    
    [Inject]
    public AppView View { get; set; }
    
}

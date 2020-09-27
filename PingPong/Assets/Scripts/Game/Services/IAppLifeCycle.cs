using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAppLifeCycle
{
    
    event Action OnUpdate;
    
    event Action OnFixedUpdate;
    
    event Action OnLateUpdate;

    event Action OnQuit;

    event Action OnPause;
    
}

using System;

namespace Game.Services
{
    
    /// <summary>
    /// Объект реализующий события жизненного цикла юнити
    /// </summary>
    public interface IAppLifeCycle
    {
    
        event Action OnUpdate;
    
        event Action OnFixedUpdate;
    
        event Action OnLateUpdate;

        event Action OnQuit;

        event Action<bool> OnPause;
    
    }
}

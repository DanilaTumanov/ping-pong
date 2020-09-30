using Game.Services.InputService;
using UnityEngine;

namespace Game.Services
{
    
    /// <summary>
    /// Сервис ввода. Содержит контроллер ввода и некоторые управляющие методы.
    /// ============================================
    /// Данный класс и весь сервис ввода был написан очень давно и нуждается в переработке.
    /// </summary>
    public interface IInputService
    {
        IInputController Controller { get; }
        
        bool IsSwipeBlocked(Object forObject);

        bool LockSwipe(Object lockOwner);

        bool UnlockSwipe(Object lockOwner);
    }
}

using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        IInputController Controller { get; }
        
        bool IsSwipeBlocked(Object forObject);

        bool LockSwipe(Object lockOwner);

        bool UnlockSwipe(Object lockOwner);
    }
}

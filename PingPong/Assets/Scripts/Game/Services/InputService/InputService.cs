using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Services.InputService
{
    
    /// <summary>
    /// См. интерфейс
    /// </summary>
    public class InputService : IInputService
    {

        public IInputController Controller { get; private set; }

        private GameObject _inputController;


        private bool _swipeLocked;
        private int _swipeLockOwnerId;
        

        public InputService(IInputController inputController)
        {
            Controller = inputController;
        }


        public bool IsSwipeBlocked(Object forObject)
        {
            return _swipeLocked && forObject.GetInstanceID() != _swipeLockOwnerId;
        }
        

        public bool LockSwipe(Object lockOwner)
        {
            var lockOwnerId = lockOwner.GetInstanceID();
            
            if (IsSwipeBlocked(lockOwner))
                return false;

            _swipeLocked = true;
            _swipeLockOwnerId = lockOwnerId;
            return true;
        }


        public bool UnlockSwipe(Object lockOwner)
        {
            if (IsSwipeBlocked(lockOwner))
                return false;
            
            _swipeLocked = false;
            _swipeLockOwnerId = 0;
            return true;
        }
        
    }
    
}
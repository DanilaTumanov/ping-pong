using System;
using UnityEngine;

namespace Game.Services.RuntimeService
{
    public class RuntimeClient : MonoBehaviour, IAppLifeCycle
    {
        public event Action OnUpdate;
        public event Action OnLateUpdate;
        public event Action OnQuit;
        public event Action OnPause;


        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        private void OnApplicationQuit()
        {
            OnQuit?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OnPause?.Invoke();
        }
    }
}

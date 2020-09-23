using System;
using UnityEngine;

namespace Game.Services.RuntimeService
{
    public class RuntimeService : IRuntimeService
    {
        public event Action OnUpdate;
        public event Action OnLateUpdate;
        public event Action OnQuit;
        public event Action OnPause;


        public RuntimeService()
        {
            var go = new GameObject("RuntimeClient");
            var runtimeClient = go.AddComponent<RuntimeClient>();
            runtimeClient.OnUpdate += () => OnUpdate?.Invoke();
            runtimeClient.OnLateUpdate += () => OnLateUpdate?.Invoke();
            runtimeClient.OnQuit += () => OnQuit?.Invoke();
            runtimeClient.OnPause += () => OnPause?.Invoke();
        }
    }
}

using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Services.RuntimeService
{
    public class RuntimeService : IRuntimeService
    {

        private GameObject _runtimeGameObject;
        private RuntimeClient _runtimeClient;
        
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action OnLateUpdate;
        public event Action OnQuit;
        public event Action OnPause;


        public RuntimeService()
        {
            _runtimeGameObject = new GameObject("RuntimeClients");
            
            Object.DontDestroyOnLoad(_runtimeGameObject);

            _runtimeClient = RegisterClient<RuntimeClient>(); 
            
            _runtimeClient.OnUpdate += () => OnUpdate?.Invoke();
            _runtimeClient.OnFixedUpdate += () => OnFixedUpdate?.Invoke();
            _runtimeClient.OnLateUpdate += () => OnLateUpdate?.Invoke();
            _runtimeClient.OnQuit += () => OnQuit?.Invoke();
            _runtimeClient.OnPause += () => OnPause?.Invoke();
        }

        public T RegisterClient<T>() where T : MonoBehaviour
        {
            return _runtimeGameObject.AddComponent<T>();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _runtimeClient.StartCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            _runtimeClient.StopCoroutine(routine);
        }
    }
}

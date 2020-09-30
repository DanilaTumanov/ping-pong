﻿using System;
using UnityEngine;

namespace Game.Services.RuntimeService
{
    
    /// <summary>
    /// Runtime клиент для отслеживания жизненного цикла объектов
    /// </summary>
    public class RuntimeClient : MonoBehaviour, IAppLifeCycle
    {
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action OnLateUpdate;
        public event Action OnQuit;
        public event Action<bool> OnPause;


        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
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
            OnPause?.Invoke(pauseStatus);
        }
    }
}

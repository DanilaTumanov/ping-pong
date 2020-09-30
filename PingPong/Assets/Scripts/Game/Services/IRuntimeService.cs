using System;
using System.Collections;
using UnityEngine;

namespace Game.Services.RuntimeService
{
    
    /// <summary>
    /// Сервис, предоставляющий часть апи MonoBehaviour,
    /// и позволяющий внедрить компоненты в жизненный цикл Unity
    /// </summary>
    public interface IRuntimeService : IAppLifeCycle
    {

        /// <summary>
        /// Зарегистрировать MonoBehaviour клиент.
        /// Он будет помещен на специальный объект на сцене,
        /// и сможет функционировать как после Instantiate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T RegisterClient<T>() where T : MonoBehaviour;

        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);

    }
}

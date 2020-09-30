using System;
using System.Collections;
using UnityEngine;

namespace Game.Services.RuntimeService
{
    public interface IRuntimeService : IAppLifeCycle
    {

        T RegisterClient<T>() where T : MonoBehaviour;

        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);

    }
}

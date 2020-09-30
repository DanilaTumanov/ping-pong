using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

/// <summary>
/// Точка входа игры
/// </summary>
public class GameRoot : ContextView
{
    private void Awake()
    {
        context = new GameContext(this);
        DontDestroyOnLoad(this);
    }
}

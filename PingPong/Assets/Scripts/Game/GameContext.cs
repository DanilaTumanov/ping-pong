using System.Collections;
using System.Collections.Generic;
using Game.Commands;
using Game.Gameplay;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using Game.Mediators;
using Game.Services.ConfigService;
using Game.Services.InputService;
using Game.Services.RuntimeService;
using Game.Signals;
using Game.Views;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using UnityEngine;

public class GameContext : MVCSContext
{
    
    public GameContext (MonoBehaviour view) : base(view)
    {
    }


    // Override Start so that we can fire the StartSignal 
    // см. пример
    public override IContext Start()
    {
        base.Start();
        StartSignal startSignal= injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }


    protected override void mapBindings()
    {
        
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        injectionBinder.Bind<IInputController>().To<InputWinController>().ToSingleton();
#elif UNITY_ANDROID || UNITY_IOS
        injectionBinder.Bind<IInputController>().To<InputMobileController>().ToSingleton();
#endif
        
        
        //Services
        injectionBinder.Bind<IRuntimeService>().To<RuntimeService>().ToSingleton();
        //injectionBinder.Bind<IObjectPoolService>().To<ObjectPool>().ToSingleton();
        injectionBinder.Bind<IPool<Ball>>().To<Pool<Ball>>().ToSingleton();
        injectionBinder.Bind<IConfigService>().To<ConfigService>().ToSingleton();
        

        // View
        mediationBinder.Bind<AppView>().To<AppMediator>();
        mediationBinder.Bind<GameplayView>().To<GameplayMediator>();
        mediationBinder.Bind<Player>().To<PlayerMediator>();
        
        
        // Start command
        commandBinder.Bind<StartSignal>().To<StartApp>().Once();

    }

}

using System.Collections;
using System.Collections.Generic;
using Game.Commands;
using Game.Mediators;
using Game.Services.InputService;
using Game.Services.RuntimeService;
using Game.Signals;
using Game.Views;
using strange.extensions.context.api;
using strange.extensions.context.impl;
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
        

        // View
        mediationBinder.Bind<AppView>().To<AppMediator>();
        mediationBinder.Bind<GameplayView>().To<GameplayMediator>();
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        
        
        // Start command
        commandBinder.Bind<StartSignal>().To<StartApp>().Once();


    }

}

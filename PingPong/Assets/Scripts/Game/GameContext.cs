using System.Collections;
using System.Collections.Generic;
using Game.Commands;
using Game.Gameplay;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using Game.Mediators;
using Game.Models;
using Game.Models.Scores;
using Game.Services;
using Game.Services.ConfigService;
using Game.Services.InputService;
using Game.Services.NetworkService;
using Game.Services.RuntimeService;
using Game.Services.UserDataService;
using Game.Signals;
using Game.Views;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
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


        injectionBinder.Bind<IDataStorageDriver>().To<PlayerPrefsStorageDriver>();
        
        
        //Services
        injectionBinder.Bind<IRuntimeService>().To<RuntimeService>().ToSingleton();
        injectionBinder.Bind<IConfigService>().To<ConfigService>().ToSingleton();
        injectionBinder.Bind<IUserDataService>().To<UserDataService>().ToSingleton();
        injectionBinder.Bind<INetworkService>().To<PhotonService>().ToSingleton();
        
        
        // Models
        injectionBinder.Bind<IScoresModel>().To<ScoresModel>().ToSingleton();
        injectionBinder.Bind<INetworkModel>().To<NetworkModel>().ToSingleton();
        

        // View
        mediationBinder.Bind<AppView>().To<AppMediator>();
        mediationBinder.Bind<GameplayView>().To<GameplayMediator>();
        mediationBinder.Bind<Player>().To<PlayerMediator>();
        mediationBinder.Bind<HudView>().To<HudMediator>();
        mediationBinder.Bind<StartMenuView>().To<StartMenuMediator>();
        
        
        // Commands
        commandBinder.Bind<OutSignal>().To<OutCommand>();
        commandBinder.Bind<HitSignal>().To<HitCommand>();
        commandBinder.Bind<JoinGameSignal>().To<JoinGameCommand>();
        
        // Start command
        commandBinder.Bind<StartSignal>().To<StartApp>().Once();
        
    }

}

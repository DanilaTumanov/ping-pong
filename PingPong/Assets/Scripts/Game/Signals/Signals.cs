using strange.extensions.signal.impl;

namespace Game.Signals
{
    
    /// <summary>
    /// Инициализация приложения
    /// </summary>
    public class StartSignal : Signal {}

    public class HitSignal : Signal {}
    
    public class OutSignal : Signal {}
    
    public class JoinGameSignal : Signal<string> {}
    
}

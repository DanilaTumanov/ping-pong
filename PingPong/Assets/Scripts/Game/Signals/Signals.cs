using strange.extensions.signal.impl;

namespace Game.Signals
{
    
    /// <summary>
    /// Инициализация приложения
    /// </summary>
    public class StartSignal : Signal {}

    /// <summary>
    /// Сигнал отбития ракеткой
    /// </summary>
    public class HitSignal : Signal {}
    
    /// <summary>
    /// Сигнал вылета мяча за пределы поля
    /// </summary>
    public class OutSignal : Signal {}
    
    /// <summary>
    /// Сигнал присоединения к игре (после него будет произведена попытка присоединения)
    /// Параметр - код комнаты Photon
    /// </summary>
    public class JoinGameSignal : Signal<string> {}
    
    /// <summary>
    /// Выбор нового фона игры
    /// параметр - индекс фона из списка в файле конфигурации
    /// </summary>
    public class SelectedBackgroundSignal : Signal<int> {}
    
    /// <summary>
    /// Закрытие окна настроек
    /// </summary>
    public class SettingsCloseButtonSignal : Signal {}
    
    /// <summary>
    /// Открытие окна настроек
    /// </summary>
    public class SettingsOpenButtonSignal : Signal {}
    
}

using Game.Services.ConfigService;

namespace Game.Services
{
    
    /// <summary>
    /// Сервис конфигурации. Предоставляет набор предустановленных настроек игры
    /// </summary>
    public interface IConfigService
    {

        Config Config { get; }

    }
}

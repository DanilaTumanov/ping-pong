using Game.Services.NetworkService;
using Game.Services.RuntimeService;
using Game.Services.UserDataService;

namespace Game.Models
{
    
    /// <summary>
    /// Базовый класс модели, загружает пользовательские данные модели,
    /// если они есть (помечены аттрибутом [Save]), и так же сохраняет их при выходе
    /// </summary>
    public abstract class Model
    {

        public Model(IUserDataService userDataService, IRuntimeService runtimeService)
        {
            userDataService.Load(this);
            runtimeService.OnQuit += () => userDataService.Save(this);
            runtimeService.OnPause += pause =>
            {
                if (pause)
                    userDataService.Save(this);
            };
        }
        
    }
}

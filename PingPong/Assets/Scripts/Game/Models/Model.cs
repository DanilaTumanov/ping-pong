using Game.Services.RuntimeService;
using Game.Services.UserDataService;

namespace Game.Models
{
    public class Model
    {

        public Model(IUserDataService userDataService, IRuntimeService runtimeService)
        {
            userDataService.Load(this);
            runtimeService.OnQuit += () => userDataService.Save(this);
        }
    
    }
}

using UnityEngine;

namespace Game.Services.UserDataService
{
    public interface IUserDataService
    {

        void Load(object userDataObject);
        void Save(object userDataObject);

    }
}

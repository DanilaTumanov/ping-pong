using UnityEngine;

namespace Game.Services.UserDataService
{
    
    /// <summary>
    /// Сервис сохранения и загрузки пользовательских данных.
    /// userDataObject - объект в котором нужные для сохранения ContextProperty
    /// отмечены аттрибутом [Save]
    /// </summary>
    public interface IUserDataService
    {

        void Load(object userDataObject);
        void Save(object userDataObject);

    }
}

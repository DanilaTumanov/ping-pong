using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Game.Models;
using UnityEngine;

namespace Game.Services.UserDataService
{
    
    /// <summary>
    /// См. интерфейс
    /// </summary>
    public class UserDataService: IUserDataService
    {
        private readonly IDataStorageDriver _dataStorageDriver;

        public UserDataService(IDataStorageDriver dataStorageDriver)
        {
            _dataStorageDriver = dataStorageDriver;
        }
        
        
        public void Load(object userDataObject)
        {
            foreach (var savePropertyData in GetSaveProperties(userDataObject))
            {
                var loaded = TryLoad(savePropertyData, _dataStorageDriver.LoadInt)
                          || TryLoad(savePropertyData, _dataStorageDriver.LoadFloat)
                          || TryLoad(savePropertyData, _dataStorageDriver.LoadString);
            }
        }

        private bool TryLoad<T>(SavePropertyData data, Func<string, T> loader)
        {
            var typeMatch = data.propertyInfo.PropertyType == typeof(T);
            
            if (typeMatch)
            {
                data.propertyInfo.SetValue(
                    data.contextPropertyInstance,
                    loader(data.name)
                );
            }

            return typeMatch;
        }

        public void Save(object userDataObject)
        {
            foreach (var savePropertyData in GetSaveProperties(userDataObject))
            {
                var saved = TrySave<int>(savePropertyData, _dataStorageDriver.SaveInt)
                         || TrySave<float>(savePropertyData, _dataStorageDriver.SaveFloat)
                         || TrySave<string>(savePropertyData, _dataStorageDriver.SaveString);
                
            }
        }
        
        private bool TrySave<T>(SavePropertyData data, Action<string, T> saver)
        {
            var typeMatch = data.propertyInfo.PropertyType == typeof(T);
            
            if (typeMatch)
            {
                saver(
                    data.name,
                    (T) data.propertyInfo.GetValue(
                        data.contextPropertyInstance
                    )
                );
            }

            return typeMatch;
        }


        private IEnumerable<SavePropertyData> GetSaveProperties(object userDataObject)
        {
            return userDataObject.GetType()
                                 .GetProperties()
                                 .Where(prop =>
                                 {
                                     var savableProp = prop.GetCustomAttribute(typeof(Save)) != null;
                                     var isContextProperty = prop.PropertyType.IsGenericType 
                                                          && prop.PropertyType.GetGenericTypeDefinition()
                                                          == typeof(ContextProperty<>);
                                     
                                     return savableProp && isContextProperty;
                                 })
                                 .Select(prop => new SavePropertyData
                                     {
                                         name = prop.Name,
                                         contextPropertyInstance = prop.GetValue(userDataObject),
                                         propertyInfo = prop.PropertyType.GetProperty("Value")
                                     }
                                 );
        }
    }


    public struct SavePropertyData
    {
        public string name;
        public object contextPropertyInstance;
        public PropertyInfo propertyInfo;
    }
}

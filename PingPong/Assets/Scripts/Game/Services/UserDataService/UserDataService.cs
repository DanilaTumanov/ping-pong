using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Game.Models;
using UnityEngine;

namespace Game.Services.UserDataService
{
    
    
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
                if (savePropertyData.propertyInfo.PropertyType == typeof(int))
                {
                    Load(savePropertyData, _dataStorageDriver.LoadInt);
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(float))
                {
                    Load(savePropertyData, _dataStorageDriver.LoadFloat);
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(string))
                {
                    Load(savePropertyData, _dataStorageDriver.LoadString);
                }
            }
        }

        private void Load<T>(SavePropertyData data, Func<string, T> loader)
        {
            data.propertyInfo.SetValue(
                data.contextPropertyInstance,
                loader(data.name)
            );
        }

        public void Save(object userDataObject)
        {
            foreach (var savePropertyData in GetSaveProperties(userDataObject))
            {
                if (savePropertyData.propertyInfo.PropertyType == typeof(int))
                {
                    Save<int>(savePropertyData, _dataStorageDriver.SaveInt);
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(float))
                {
                    Save<float>(savePropertyData, _dataStorageDriver.SaveFloat);
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(string))
                {
                    Save<string>(savePropertyData, _dataStorageDriver.SaveString);
                }
            }
            
        }
        
        private void Save<T>(SavePropertyData data, Action<string, T> saver)
        {
            saver(
                data.name,
                (T) data.propertyInfo.GetValue(
                    data.contextPropertyInstance
                )
            );
        }


        private IEnumerable<SavePropertyData> GetSaveProperties(object userDataObject)
        {
            return userDataObject.GetType()
                                 .GetProperties()
                                 .Where(prop =>
                                 {
                                     var savableProp = prop.GetCustomAttribute(typeof(Save));
                                     var isContextProperty = false;

                                     if (prop.PropertyType.IsGenericType)
                                     {
                                         if (prop.PropertyType.GetGenericTypeDefinition()
                                          == typeof(ContextProperty<>))
                                         {
                                             isContextProperty = true;
                                         }
                                     }

                                     return savableProp != null && isContextProperty;
                                 })
                                 .Select(prop =>
                                 {
                                     return new SavePropertyData
                                     {
                                         name = prop.Name,
                                         contextPropertyInstance = prop.GetValue(userDataObject),
                                         propertyInfo = prop.PropertyType.GetProperty("Value")
                                     };
                                 });
        }
    }


    public struct SavePropertyData
    {
        public string name;
        public object contextPropertyInstance;
        public PropertyInfo propertyInfo;
    }
}

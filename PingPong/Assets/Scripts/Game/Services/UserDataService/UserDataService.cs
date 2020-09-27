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
        
        public void Load(object userDataObject)
        {
            foreach (var savePropertyData in GetSaveProperties(userDataObject))
            {
                if (savePropertyData.propertyInfo.PropertyType == typeof(int))
                {
                    savePropertyData.propertyInfo.SetValue(
                        savePropertyData.contextPropertyInstance,
                        PlayerPrefs.GetInt(
                            savePropertyData.name, 
                            (int) savePropertyData.propertyInfo.GetValue(
                                savePropertyData.contextPropertyInstance
                            )
                        )
                    );
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(float))
                {
                    savePropertyData.propertyInfo.SetValue(
                        savePropertyData.contextPropertyInstance,
                        PlayerPrefs.GetFloat(
                            savePropertyData.name, 
                            (float) savePropertyData.propertyInfo.GetValue(
                                savePropertyData.contextPropertyInstance
                            )
                        )
                    );
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(string))
                {
                    savePropertyData.propertyInfo.SetValue(
                        savePropertyData.contextPropertyInstance,
                        PlayerPrefs.GetString(
                            savePropertyData.name, 
                            (string) savePropertyData.propertyInfo.GetValue(
                                savePropertyData.contextPropertyInstance
                            )
                        )
                    );
                }
            }
        }

        public void Save(object userDataObject)
        {
            foreach (var savePropertyData in GetSaveProperties(userDataObject))
            {
                if (savePropertyData.propertyInfo.PropertyType == typeof(int))
                {
                    PlayerPrefs.SetInt(
                        savePropertyData.name, 
                        (int) savePropertyData.propertyInfo.GetValue(
                            savePropertyData.contextPropertyInstance
                        )
                    );
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(float))
                {
                    PlayerPrefs.SetFloat(
                        savePropertyData.name, 
                        (float) savePropertyData.propertyInfo.GetValue(
                            savePropertyData.contextPropertyInstance
                        )
                    );
                }
                else if (savePropertyData.propertyInfo.PropertyType == typeof(string))
                {
                    PlayerPrefs.SetString(
                        savePropertyData.name, 
                        (string) savePropertyData.propertyInfo.GetValue(
                            savePropertyData.contextPropertyInstance
                        )
                    );
                }
            }
            PlayerPrefs.Save();
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

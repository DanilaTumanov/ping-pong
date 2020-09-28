using System;
using UnityEngine;

namespace Game.Services.UserDataService
{
    public class PlayerPrefsStorageDriver : IDataStorageDriver
    {
        public void SaveInt(string name, int value)
        {
            Save(name, value, PlayerPrefs.SetInt);
        }

        public void SaveFloat(string name, float value)
        {
            Save(name, value, PlayerPrefs.SetFloat);
        }

        public void SaveString(string name, string value)
        {
            Save(name, value, PlayerPrefs.SetString);
        }


        private void Save<T>(string name, T value, Action<string, T> save)
        {
            save(name, value);
            PlayerPrefs.Save();
        }
        

        public int LoadInt(string name)
        {
            return Load<int>(name, PlayerPrefs.GetInt);
        }

        public float LoadFloat(string name)
        {
            return Load<float>(name, PlayerPrefs.GetFloat);
        }

        public string LoadString(string name)
        {
            return Load<string>(name, PlayerPrefs.GetString);
        }

        private T Load<T>(string name, Func<string, T, T> load)
        {
            return load(name, default);
        }
    }
}

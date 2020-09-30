﻿namespace Game.Services.UserDataService
{
    
    /// <summary>
    /// Драйвер сохранения пользовательских данных
    /// </summary>
    public interface IDataStorageDriver
    {

        void SaveInt(string name, int value);
        void SaveFloat(string name, float value);
        void SaveString(string name, string value);

        int LoadInt(string name);
        float LoadFloat(string name);
        string LoadString(string name);
    }
}

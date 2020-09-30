using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    
    /// <summary>
    /// Настройки игры
    /// </summary>
    public interface ISettingsModel
    {
    
        ContextProperty<int> SelectedBackground { get; }
        ContextProperty<List<Sprite>> BackgroundsList { get; }
    
    }
}

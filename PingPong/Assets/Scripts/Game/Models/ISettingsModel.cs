using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    public interface ISettingsModel
    {
    
        ContextProperty<int> SelectedBackground { get; }
        ContextProperty<List<Sprite>> BackgroundsList { get; }
    
    }
}

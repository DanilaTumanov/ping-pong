using UnityEngine;

namespace Game.Gameplay.InteractionInterfaces
{
    
    /// <summary>
    /// Объект, имеющий прямоугольные границы
    /// </summary>
    public interface IBoundedObject
    {
        
        Transform Transform { get; }
        Bounds Bounds { get; }
        
    }
}

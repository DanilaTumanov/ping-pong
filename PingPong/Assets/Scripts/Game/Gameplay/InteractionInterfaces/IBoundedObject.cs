using UnityEngine;

namespace Game.Gameplay
{
    public interface IBoundedObject
    {
        
        Transform Transform { get; }
        Bounds Bounds { get; }
        
    }
}

using UnityEngine;

namespace Game.Gameplay
{
    public interface IRestrictedArea
    {
    
        Bounds Bounds { get; }

        bool IsObjectInside(IBoundedObject obj);
        bool IsObjectOutside(IBoundedObject obj);

    }
}

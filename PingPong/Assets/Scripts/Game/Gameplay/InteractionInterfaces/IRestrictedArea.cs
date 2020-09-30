using Game.Gameplay.InteractionInterfaces;
using UnityEngine;

namespace Game.Gameplay
{
    
    /// <summary>
    /// Ограниченная область, которая может определять находится ли в ней или вне ее некий объект
    /// </summary>
    public interface IRestrictedArea
    {
    
        /// <summary>
        /// Границы области
        /// </summary>
        Bounds Bounds { get; }

        /// <summary>
        /// Находится ли объект полностью внутри области
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsObjectInside(IBoundedObject obj);
        
        /// <summary>
        /// Находится ли объект полностью за пределами области
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsObjectOutside(IBoundedObject obj);

    }
}

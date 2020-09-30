using UnityEngine;

namespace Game.Gameplay
{
    
    /// <summary>
    /// Объект, который может быть отбит ракеткой
    /// </summary>
    public interface IHitable
    {

        /// <summary>
        /// Отбить объект
        /// </summary>
        /// <param name="point">Точка соприкосновения с отбивающей поверхностью</param>
        /// <param name="normal">Нормаль к отбивающей поверхности</param>
        void Hit(Vector3 point, Vector3 normal);

    }
}

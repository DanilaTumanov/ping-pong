using Game.Gameplay.InteractionInterfaces;
using UnityEngine;

namespace Game.Gameplay.Field.Bounds
{
    
    /// <summary>
    /// Ограничитель игрового поля, который приводит к выходу объекта с поля (аут)
    /// </summary>
    public class OutBound : FieldBound
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            var outObject = other.transform.GetComponent<IOutObject>();

            outObject?.Out();
        }
    }
}

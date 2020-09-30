using System;
using UnityEngine;

namespace Game.Gameplay.Field.Bounds
{
    
    /// <summary>
    /// Ограничитель одной стороны игрового поля
    /// </summary>
    public class FieldBound : MonoBehaviour
    {

        [SerializeField] private BoxCollider2D _collider;
        
        private Vector2 _pivot = Vector2.one / 2;
        

        public void SetSize(Vector2 size)
        {
            _collider.size = size;    
            SetPivot(_pivot);
        }

        /// <summary>
        /// Установка пивота коллайдера по аналогии с UI - в нормализованных координатах
        /// </summary>
        /// <param name="pivot"></param>
        public void SetPivot(Vector2 pivot)
        {
            _pivot = pivot;
            _collider.offset = (-2 * pivot + Vector2.one) * _collider.size / 2f;
        }
    }
}

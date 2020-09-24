using Game.Gameplay;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Views
{
    public class PlayerView : View, IBoundedObject
    {
        
        [SerializeField] private BoxCollider2D _collider;

        private IRestrictedArea _restrictedArea;
        
        
        public Transform Transform => transform;
        public Bounds Bounds => _collider.bounds;


        public void SetRestrictedArea(IRestrictedArea area)
        {
            _restrictedArea = area;
        }
        

        public void Move(Vector3 offset)
        {
            var oldPos = transform.position;
            transform.position += transform.right * Vector3.Dot(offset, transform.right);

            if (!_restrictedArea.IsObjectInside(this))
            {
                transform.position = oldPos;
            }
        }
    }
}

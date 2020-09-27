using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Gameplay
{
    [DisallowMultipleComponent]
    public class Player : View, IBoundedObject
    {
        
        [SerializeField] private BoxCollider2D _collider;

        private IRestrictedArea _restrictedArea;
        private Vector3 _oldPos;
        
        public Transform Transform => transform;
        public Bounds Bounds => _collider.bounds;


        protected override void Awake()
        {
            _oldPos = transform.position;
        }

        public void SetRestrictedArea(IRestrictedArea area)
        {
            _restrictedArea = area;
        }
        

        public void Move(Vector3 offset)
        {
            _oldPos = transform.position;
            transform.position += transform.right * Vector3.Dot(offset, transform.right);

            if (!_restrictedArea.IsObjectInside(this))
            {
                transform.position = _oldPos;
            }
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            var hitable = other.gameObject.GetComponent<IHitable>();

            hitable?.Hit(
                other.contacts[0].point,
                other.contacts[0].normal
            );
        }
    }
}

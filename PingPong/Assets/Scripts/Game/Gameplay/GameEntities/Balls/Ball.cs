using System;
using Game.Gameplay.InteractionInterfaces;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Balls
{
 
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : View, IHitable, IOutObject
    {
        private const float SPEED_THRESHOLD = 0.01f;
        
        [SerializeField] protected float _speed = 1;


        private Rigidbody2D _rb;
        
        
        public Transform Transform { get; }

        public Bounds Bounds { get; }


        public event Action OnBallOut;
        public event Action OnBallHit;


        protected override void Awake()
        {
            base.Awake();

            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rb.velocity.sqrMagnitude > SPEED_THRESHOLD)
            {
                _rb.velocity = Vector3.Lerp(_rb.velocity, _rb.velocity.normalized * _speed, Time.fixedDeltaTime);
            }
        }

        public void Go(Vector2 direction)
        {
            _rb.AddForce(_speed * _rb.mass * direction, ForceMode2D.Impulse);
        }
        
        public void Out()
        {
            OnBallOut?.Invoke();
            Destroy(gameObject);
        }
        
        public virtual void Hit(Vector3 point, Vector3 normal)
        {
            OnBallHit?.Invoke();
        }
    }
}

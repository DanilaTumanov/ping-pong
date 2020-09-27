using UnityEngine;

namespace Game.Gameplay.GameEntities.Balls
{
    public class AcceleratingBall : Ball
    {
        [SerializeField] private float _accelerationRate = 0.5f;
        
        public override void Hit(Vector3 point, Vector3 normal)
        {
            base.Hit(point, normal);
            
            _speed += _accelerationRate;
        }
    }
}

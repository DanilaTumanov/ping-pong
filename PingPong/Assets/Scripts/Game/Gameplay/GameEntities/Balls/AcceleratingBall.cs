using UnityEngine;

namespace Game.Gameplay.GameEntities.Balls
{
    
    /// <summary>
    /// Класс, описывающий поведение мяча, который ускоряется при каждом ударе ракеткой
    /// </summary>
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

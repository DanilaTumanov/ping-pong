using UnityEngine;

namespace Game.Gameplay.GameEntities.Balls
{
    public class DecreasingBall : Ball
    {
        [SerializeField] private Transform _view;
        [SerializeField] private float _decreaseRate;
        [SerializeField] private float _minSize;
        
        public override void Hit(Vector3 point, Vector3 normal)
        {
            base.Hit(point, normal);
            
            _view.transform.localScale /= _decreaseRate;
            
            if(_view.transform.localScale.x < _minSize)
                _view.transform.localScale = Vector3.one * _minSize;
        }
    }
}

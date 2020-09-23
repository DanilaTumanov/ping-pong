using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class GameField : MonoBehaviour
    {
        [SerializeField] private BoundsPairs _bounceBounds;

        private Camera _camera;

        private List<IGameFieldObject> _objectsInGame = new List<IGameFieldObject>();


        public Bounds Bounds { get; private set; }
        public BoundsPairs BounceBounds => _bounceBounds;


        private void Awake()
        {
            _camera = Camera.main;
            Reset();
        }


        private void Update()
        {
            _objectsInGame.ForEach(gfo => Process(gfo));
        }


        private void CalculateBounds()
        {
            Bounds = new Bounds(
                _camera.transform.position,
                new Vector3(
                    _camera.orthographicSize * _camera.aspect * 2,
                    _camera.orthographicSize * 2,
                    0
                )
            );
        }


        private void Process(IGameFieldObject gameFieldObject)
        {
            if (gameFieldObject.Position.x - gameFieldObject.Bounds.extents.x < Bounds.min.x
             || gameFieldObject.Position.x + gameFieldObject.Bounds.extents.x > Bounds.max.x)
            {
                if (_bounceBounds == BoundsPairs.LeftRight)
                {
                    gameFieldObject.Bounce(gameFieldObject.Position.x > Bounds.center.x ? Vector3.left : Vector3.right);
                }
                else
                {
                    gameFieldObject.OnOut();
                }
            }
            else if (gameFieldObject.Position.y - gameFieldObject.Bounds.extents.y < Bounds.min.y
                  || gameFieldObject.Position.y + gameFieldObject.Bounds.extents.y > Bounds.max.y)
            {
                if (_bounceBounds == BoundsPairs.TopBottom)
                {
                    gameFieldObject.Bounce(gameFieldObject.Position.y > Bounds.center.y ? Vector3.down : Vector3.up);
                }
                else
                {
                    gameFieldObject.OnOut();
                }
            }
        }


        public void Place(IGameFieldObject gameFieldObject)
        {
            _objectsInGame.Add(gameFieldObject);
        }


        public void Reset()
        {
            CalculateBounds();
            _objectsInGame.ForEach(gfo => gfo.OnGameFieldReset());
            _objectsInGame.Clear();
        }


    
        private void OnDrawGizmos()
        {
            CalculateBounds();
        
            Gizmos.color = _bounceBounds == BoundsPairs.LeftRight ? Color.red : Color.green;
            Gizmos.DrawRay(Bounds.min, Vector3.right * Bounds.size.x);
            Gizmos.DrawRay(Bounds.max, Vector3.left * Bounds.size.x);
        
            Gizmos.color = _bounceBounds == BoundsPairs.LeftRight ? Color.green : Color.red;
            Gizmos.DrawRay(Bounds.min, Vector3.up * Bounds.size.y);
            Gizmos.DrawRay(Bounds.max, Vector3.down * Bounds.size.y);
        }
    }

    public enum BoundsPairs
    {
        TopBottom,
        LeftRight
    }
}
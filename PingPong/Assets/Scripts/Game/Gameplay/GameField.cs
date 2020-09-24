using System;
using System.Collections;
using System.Collections.Generic;
using Game.Views;
using UnityEngine;

namespace Game.Gameplay
{
    
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class GameField : MonoBehaviour, IRestrictedArea
    {
        [SerializeField] private BoundsPairs _bounceBounds;

        [SerializeField] private float _playerOffset;

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
            var gfoPosition = gameFieldObject.Transform.position;
            
            if (gfoPosition.x - gameFieldObject.Bounds.extents.x < Bounds.min.x
             || gfoPosition.x + gameFieldObject.Bounds.extents.x > Bounds.max.x)
            {
                if (_bounceBounds == BoundsPairs.LeftRight)
                {
                    gameFieldObject.Bounce(gfoPosition.x > Bounds.center.x ? Vector3.left : Vector3.right);
                }
                else
                {
                    gameFieldObject.OnOut();
                }
            }
            else if (gfoPosition.y - gameFieldObject.Bounds.extents.y < Bounds.min.y
                  || gfoPosition.y + gameFieldObject.Bounds.extents.y > Bounds.max.y)
            {
                if (_bounceBounds == BoundsPairs.TopBottom)
                {
                    gameFieldObject.Bounce(gfoPosition.y > Bounds.center.y ? Vector3.down : Vector3.up);
                }
                else
                {
                    gameFieldObject.OnOut();
                }
            }
        }


        public void Place(IGameFieldObject gameFieldObject)
        {
            gameFieldObject.Transform.SetParent(transform);
            _objectsInGame.Add(gameFieldObject);
        }


        public void PlacePlayers(PlayerView player1, PlayerView player2)
        {
            if (_bounceBounds == BoundsPairs.LeftRight)
            {
                player1.transform.localPosition = new Vector3(0, Bounds.min.y + _playerOffset, 0);
                player1.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                player2.transform.localPosition = new Vector3(0, Bounds.max.y - _playerOffset, 0);
                player2.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
            }
            else
            {
                player1.transform.localPosition = new Vector3(Bounds.min.x + _playerOffset, 0, 0);
                player1.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
                player2.transform.localPosition = new Vector3(Bounds.max.x - _playerOffset, 0, 0);
                player2.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            }
            
            player1.SetRestrictedArea(this);
            player2.SetRestrictedArea(this);
        }


        public void Reset()
        {
            CalculateBounds();
            _objectsInGame.ForEach(gfo => gfo.OnGameFieldReset());
            _objectsInGame.Clear();
        }


        public bool IsObjectInside(IBoundedObject obj)
        {
            var objectPos = obj.Transform.position;

            return !(objectPos.x - obj.Bounds.extents.x < Bounds.min.x
             || objectPos.x + obj.Bounds.extents.x > Bounds.max.x
             || objectPos.y - obj.Bounds.extents.y < Bounds.min.y
             || objectPos.y + obj.Bounds.extents.y > Bounds.max.y);
        }


        public bool IsObjectOutside(IBoundedObject obj)
        {
            var objectPos = obj.Transform.position;

            return objectPos.x + obj.Bounds.extents.x < Bounds.min.x
                || objectPos.x - obj.Bounds.extents.x > Bounds.max.x
                || objectPos.y + obj.Bounds.extents.y < Bounds.min.y
                || objectPos.y - obj.Bounds.extents.y > Bounds.max.y;
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
            
            Gizmos.color = Color.blue;
            if (_bounceBounds == BoundsPairs.LeftRight)
            {
                Gizmos.DrawSphere(new Vector3(0, Bounds.min.y + _playerOffset, 0), 0.2f);
                Gizmos.DrawSphere(new Vector3(0, Bounds.max.y - _playerOffset, 0),0.2f);
            }
            else
            {
                Gizmos.DrawSphere(new Vector3(Bounds.min.x + _playerOffset, 0, 0), 0.2f);
                Gizmos.DrawSphere(new Vector3(Bounds.max.x - _playerOffset, 0, 0), 0.2f);
            }
        }
    }

    public enum BoundsPairs
    {
        TopBottom,
        LeftRight
    }
}
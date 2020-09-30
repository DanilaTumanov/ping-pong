using System;
using System.Collections.Generic;
using Game.Gameplay.Field.Bounds;
using Game.Gameplay.InteractionInterfaces;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Gameplay.Field
{
    
    [DisallowMultipleComponent]
    public class GameField : MonoBehaviour, IRestrictedArea
    {
        private const float BOUND_THICKNESS = 1;
        
        [SerializeField] private BoundsPairs _bounceBoundsPair;
        [SerializeField] private float _playerOffset;
        [SerializeField] private FieldBound _bounceBoundPrefab;
        [SerializeField] private OutBound _outBoundPrefab;

        private Camera _camera;
        private FieldBound[] _bounceBounds = new FieldBound[2];
        private OutBound[] _outBounds = new OutBound[2];
        
        public UnityEngine.Bounds Bounds { get; private set; }


        private void Awake()
        {
            _camera = Camera.main;

            _bounceBounds[0] = Instantiate(_bounceBoundPrefab, transform);
            _bounceBounds[1] = Instantiate(_bounceBoundPrefab, transform);
            _outBounds[0] = Instantiate(_outBoundPrefab, transform);
            _outBounds[1] = Instantiate(_outBoundPrefab, transform);
            
            Reset();
        }


        private void CalculateBounds()
        {
            Bounds = new UnityEngine.Bounds(
                _camera.transform.position,
                new Vector3(
                    _camera.orthographicSize * _camera.aspect * 2,
                    _camera.orthographicSize * 2,
                    0
                )
            );
        }
        

        public void PlacePlayers(Player player, bool isMasterClient)
        {
            if (isMasterClient)
            {
                if (_bounceBoundsPair == BoundsPairs.LeftRight)
                {
                    player.transform.localPosition = new Vector3(0, Bounds.min.y + _playerOffset, 0);
                    player.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                }
                else
                {
                    player.transform.localPosition = new Vector3(Bounds.min.x + _playerOffset, 0, 0);
                    player.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
                }
            }
            else
            {
                if (_bounceBoundsPair == BoundsPairs.LeftRight)
                {
                    player.transform.localPosition = new Vector3(0, Bounds.max.y - _playerOffset, 0);
                    player.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
                }
                else
                {
                    player.transform.localPosition = new Vector3(Bounds.max.x - _playerOffset, 0, 0);
                    player.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
                }
            }
            
            player.SetRestrictedArea(this);
        }


        private void PlaceBounds()
        {
            var left = _bounceBoundsPair == BoundsPairs.LeftRight
                       ? _bounceBounds[0]
                       : _outBounds[0];

            var right = _bounceBoundsPair == BoundsPairs.LeftRight
                        ? _bounceBounds[1]
                        : _outBounds[1];

            var top = _bounceBoundsPair == BoundsPairs.LeftRight
                      ? _outBounds[0]
                      : _bounceBounds[0];
            
            var bottom = _bounceBoundsPair == BoundsPairs.LeftRight
                         ? _outBounds[1]
                         : _bounceBounds[1];
            
            
            PlaceBound(
                left,
                new Vector2(BOUND_THICKNESS, Bounds.size.y), 
                new Vector2(1, .5f),
                new Vector2(Bounds.min.x, Bounds.center.y)
            );
            
            PlaceBound(
                right,
                new Vector2(BOUND_THICKNESS, Bounds.size.y), 
                new Vector2(0, .5f),
                new Vector2(Bounds.max.x, Bounds.center.y)
            );
            
            PlaceBound(
                top,
                new Vector2(Bounds.size.x, BOUND_THICKNESS), 
                new Vector2(.5f, 0),
                new Vector2(Bounds.center.x, Bounds.max.y)
            );
            
            PlaceBound(
                bottom,
                new Vector2(Bounds.size.x, BOUND_THICKNESS), 
                new Vector2(.5f, 1),
                new Vector2(Bounds.center.x, Bounds.min.y)
            );
        }

        private void PlaceBound(FieldBound bound, Vector2 size, Vector2 pivot, Vector2 position)
        {
            bound.SetSize(size);
            bound.SetPivot(pivot);
            bound.transform.position = position;
        }
        
        public void Reset()
        {
            CalculateBounds();
            PlaceBounds();
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
        
    }

    public enum BoundsPairs
    {
        TopBottom,
        LeftRight
    }
}
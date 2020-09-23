using System;
using System.Collections.Generic;
using Game.Services.RuntimeService;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Services.InputService
{

    public abstract class InputStdCore
    {
        private const bool BLOCK_OVER_UI = false;

        protected int _screenWidth;
        protected int _screenHeight;
        protected int _maxSideSize;
        

        protected bool _blockInput = false;

        // Флаг блокирования ввода, идущий с отставанием в кадр. 
        // Снятие пальца не может проверить на текущем кадре находился ли палец в том или ином месте, поэтому ориентируемся на предыдущий кадр
        protected bool _blockInputLate = false;

        // Признак принудительной блокировки ввода
        protected bool _forceBlockInput = false;
        private bool _eventSystem;


        public InputStdCore(IRuntimeService runtimeService)
        {
            _eventSystem = EventSystem.current == null;
            SetScreenBounds();

            runtimeService.OnUpdate += Update;
            runtimeService.OnLateUpdate += LateUpdate;
        }


        protected virtual void Update()
        {
            _blockInput = IsInputBlocked();
            //Debug.Log($"FRAME {Time.frameCount}: InputBlocked = {_blockInput}");
            CacheInput();
        }


        protected virtual void LateUpdate()
        {
            _blockInputLate = IsInputBlocked();
        }



        protected abstract void CacheInput();
        
        

        /// <summary>
        /// Заблокировать ввод
        /// </summary>
        public void BlockInput()
        {
            _forceBlockInput = true;
        }

        /// <summary>
        /// Разблокировать ввод
        /// </summary>
        public void UnblockInput()
        {
            _forceBlockInput = false;
        }



        private void SetScreenBounds()
        {
            _screenHeight = Screen.height;
            _screenWidth = Screen.width;
            _maxSideSize = Math.Max(_screenHeight, _screenWidth);
        }



        protected abstract int[] GetPointerIds();
        
        protected abstract Vector2 GetTouchPosition();




        protected bool IsInputBlocked()
        {
            //Debug.Log($"FRAME {Time.frameCount}: ForceBlockInput = {_forceBlockInput}");
            return _forceBlockInput || HandleUIInteraction();
        }

        private bool HandleUIInteraction()
        {
            if (!BLOCK_OVER_UI)
                return false;


            int[] pointerIds = GetPointerIds();
            int i = 0;
            bool isUIInteraction = false;

            //Debug.Log($"FRAME {Time.frameCount}: pointerIds.Length = {pointerIds.Length}");
            
            isUIInteraction = IsPointerOverUIObject(GetTouchPosition());
            
            /*if (pointerIds.Length > 0)
            {
                if (pointerIds[0] >= 0)
                {
                    do
                    {
                        //isUIInteraction = IsUIInteraction(pointerIds[i++]);
                        isUIInteraction = IsPointerOverUIObject(GetTouchPosition());
                    }
                    while (!isUIInteraction && pointerIds[i] >= 0 && i < pointerIds.Length);
                }
            }
            else
            {
                isUIInteraction = IsPointerOverUIObject(GetTouchPosition());
            }*/

            return isUIInteraction;
        }



        /*protected virtual bool IsUIInteraction(int pointerId)
        {
            if (_eventSystem)
                return false;

            Debug.Log($"FRAME {Time.frameCount}: EventSystem.current.IsPointerOverGameObject({pointerId}) = {EventSystem.current.IsPointerOverGameObject(pointerId)}");
            
            return pointerId >= 0 ? EventSystem.current.IsPointerOverGameObject(pointerId) : EventSystem.current.IsPointerOverGameObject();
        }

        protected virtual bool IsUIInteraction()
        {
            return IsUIInteraction(-1);
        }*/

        
        
        private bool IsPointerOverUIObject(Vector2 touchPosition) {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = touchPosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            
            //Debug.Log($"FRAME {Time.frameCount}: RaycastAll count = {results.Count}");
            
            return results.Count > 0;
        }

    }

}
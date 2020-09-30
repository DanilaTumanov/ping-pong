using Game.Services.RuntimeService;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Services.InputService
{
    public class InputWinController : Game.Services.InputService.InputController
    {
        private int[] _pointerIds = new int[0];

        
        public InputWinController(IRuntimeService runtimeService) : base(runtimeService)
        {
        }

        
        protected override Vector3 GetDeltaTouchPosition()
        {
            return GetTouchPosition() - OldTouchPosition;
        }

        protected override bool GetIsTap()
        {
            return Input.GetMouseButton((int)MouseButton.LeftMouse) && !_blockInput;
        }

        protected override bool GetIsTapDown()
        {
            return Input.GetMouseButtonDown((int)MouseButton.LeftMouse) && !_blockInput;
        }

        protected override bool GetIsTapUp()
        {
            return Input.GetMouseButtonUp((int)MouseButton.LeftMouse) && !_blockInputLate;
        }

        protected override bool GetIsMultipleTouch()
        {
            return Input.GetMouseButton((int)MouseButton.LeftMouse) && Input.GetMouseButton((int)MouseButton.RightMouse);
        }

        protected override bool GetIsScreenTap()
        {
            return Input.GetMouseButton((int)MouseButton.LeftMouse);
        }

        protected override bool GetIsScreenTapDown()
        {
            return Input.GetMouseButtonDown((int)MouseButton.LeftMouse);
        }

        protected override bool GetIsScreenTapUp()
        {
            return Input.GetMouseButtonUp((int)MouseButton.LeftMouse);
        }

        protected override Vector2 GetTouchPosition()
        {
            if (Input.GetMouseButton((int)MouseButton.LeftMouse))
                return Input.mousePosition;
            else
                return Vector3.zero;
        }

        protected override float GetHorizontalSwipe()
        {
            return !Input.GetKey(KeyCode.LeftShift) ? Input.GetAxis("Horizontal") * 0.1f : 0;
        }

        protected override float GetVerticalSwipe()
        {
            return !Input.GetKey(KeyCode.LeftShift) ? Input.GetAxis("Vertical") * 0.1f : 0;
        }

        protected override float GetHorizontalDoubleSwipe()
        {
            return Input.GetKey(KeyCode.LeftShift) ? Input.GetAxis("Horizontal") * 0.1f : 0;
        }

        protected override float GetVerticalDoubleSwipe()
        {
            return Input.GetKey(KeyCode.LeftShift) ? Input.GetAxis("Vertical") * 0.1f : 0;
        }

        protected override float GetZoom()
        {
            return -Input.GetAxis("Mouse ScrollWheel") * 1;
        }

        protected override Vector2 GetZoomPoint()
        {
            return Input.mousePosition;
        }

        protected override int[] GetPointerIds()
        {
            return _pointerIds;
        }

        protected override float GetRotation()
        {
            var angle = 0;

            if (Input.GetKey(KeyCode.Minus))
                angle -= 1;
            if (Input.GetKey(KeyCode.Equals))
                angle += 1;

            return angle;
        }

        protected override Vector2 GetSwipeVector()
        {
            return new Vector2(GetHorizontalSwipe(), GetVerticalSwipe());
        }

        protected override Vector2 GetDoubleSwipeVector()
        {
            return new Vector2(GetHorizontalDoubleSwipe(), GetVerticalDoubleSwipe());
        }
    }
}

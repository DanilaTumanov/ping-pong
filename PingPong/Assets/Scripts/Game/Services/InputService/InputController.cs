using Game.Services.RuntimeService;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Services.InputService
{
    public abstract class InputController: InputStdCore, IInputController
    {
        
        /// <summary>
        /// Возвращает true, если пользователь удерживает палец на экране 
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        public bool IsTap { get; protected set; }

        /// <summary>
        /// Возвращает true если пользователь поставил палец на экран.
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        public bool IsTapDown { get; protected set; }

        /// <summary>
        /// Возвращает true если пользователь убрал палец с экрана.
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        public bool IsTapUp { get; protected set; }

        /// <summary>
        /// Возвращает true, если пользователь удерживает палец на экране
        /// </summary>
        /// <returns></returns>
        public bool IsScreenTap { get; protected set; }

        /// <summary>
        /// Возвращает true если пользователь поставил палец на экран.
        /// </summary>
        /// <returns></returns>
        public bool IsScreenTapDown { get; protected set; }

        /// <summary>
        /// Возвращает true, если пользователь убрал палец с экрана.
        /// </summary>
        /// <returns></returns>
        public bool IsScreenTapUp { get; protected set; }

        
        /// <summary>
        /// Возвращает true, если пользователь удерживает несколько пальцев на экране
        /// </summary>
        public bool IsMultipleTouch { get; protected set; }
        
        
        /// <summary>
        /// Возвращает вектор движения пальца влево-вправо, вверх-вниз.
        /// </summary>
        public Vector3 DeltaTouchPosition { get; protected set; }

        /// <summary>
        /// Возвращает точку нажатия по экрану. При обработке отпускания пальца используейте OldTouchPosition
        /// </summary>
        public Vector2 TouchPosition { get; protected set; }

        /// <summary>
        /// Возвращает точку нажатия по экрану на прошлом кадре.
        /// Нужно для определения позиции при отпускании пальца
        /// </summary>
        public Vector2 OldTouchPosition { get; protected set; }

        /// <summary>
        /// Возвращает расстояние горизонтального свайпа
        /// Положительное - вправо
        /// Отрицательное - влево
        /// </summary>
        public float HorizontalSwipe { get; protected set; }

        /// <summary>
        /// Возвращает расстояние вертикального свайпа
        /// Положительное - вверх
        /// Отрицательное - вниз
        /// </summary>
        public float VerticalSwipe { get; protected set; }

        /// <summary>
        /// Возвращает расстояние горизонтального свайпа двумя пальцами
        /// Положительное - вправо
        /// Отрицательное - влево
        /// </summary>
        public float HorizontalDoubleSwipe { get; protected set; }

        /// <summary>
        /// Возвращает расстояние вертикального свайпа двумя пальцами
        /// Положительное - вверх
        /// Отрицательное - вниз
        /// </summary>
        /// <returns></returns>
        public float VerticalDoubleSwipe { get; protected set; }

        /// <summary>
        /// Возвращает уровень зума (положительный - разведение пальцев, отрицательный - сведение)
        /// </summary>
        /// <returns></returns>
        public float Zoom { get; protected set; }
        
        /// <summary>
        /// Возвращает позицию точки зума на экране (между двумя пальцами)
        /// </summary>
        /// <returns></returns>
        public Vector2 ZoomPoint { get; protected set; }

        /// <summary>
        /// Возвращает угол поворота, заданный жестом поворота в текущем кадре
        /// </summary>
        public float Rotation { get; protected set; }

        /// <summary>
        /// Вектор, показывающий направление свайпа
        /// </summary>
        public Vector2 SwipeVector { get; protected set; }
        
        /// <summary>
        /// Вектор, показывающий направление двойного свайпа
        /// </summary>
        public Vector2 DoubleSwipeVector { get; protected set; }

        /// <summary>
        /// Возвращает true, если производится свайп
        /// </summary>
        public bool IsSwipe { get; protected set; }
        
        /// <summary>
        /// Возвращает true, если производится двойной свайп
        /// </summary>
        public bool IsDoubleSwipe { get; protected set; }
        
        /// <summary>
        /// Возвращает true, если производится зум
        /// </summary>
        public bool IsZoom { get; protected set; }


        public bool WasAnySwipe { get; protected set; }






        public UnityEvent OnTapDown { get; protected set; } = new UnityEvent();

        public UnityEvent OnTapUp { get; protected set; } = new UnityEvent();

        public UnityEvent OnScreenTapDown { get; protected set; } = new UnityEvent();

        public UnityEvent OnScreenTapUp { get; protected set; } = new UnityEvent();

        public UnityEvent OnSwipe { get; protected set; } = new UnityEvent();
        
        public UnityEvent OnDoubleSwipe { get; protected set; } = new UnityEvent();

        public UnityEvent OnZoom { get; protected set; } = new UnityEvent();


        private Vector2 _tapStart;


        protected abstract bool GetIsTap();

        protected abstract bool GetIsTapDown();

        protected abstract bool GetIsTapUp();

        protected abstract bool GetIsScreenTap();

        protected abstract bool GetIsScreenTapDown();

        protected abstract bool GetIsScreenTapUp();

        protected abstract bool GetIsMultipleTouch();

        protected abstract Vector3 GetDeltaTouchPosition();


        //protected abstract Vector2 GetTouchPosition()

        protected abstract float GetHorizontalSwipe();

        protected abstract float GetVerticalSwipe();

        protected abstract float GetHorizontalDoubleSwipe();

        protected abstract float GetVerticalDoubleSwipe();

        protected abstract float GetZoom();

        protected abstract Vector2 GetZoomPoint();

        protected abstract float GetRotation();

        protected abstract Vector2 GetSwipeVector();

        protected abstract Vector2 GetDoubleSwipeVector();


        
        protected InputController(IRuntimeService runtimeService) : base(runtimeService)
        {
        }
        
        

        protected bool GetIsSwipe()
        {
            return VerticalSwipe != 0 || HorizontalSwipe != 0;
        }

        protected bool GetIsDoubleSwipe()
        {
            return VerticalDoubleSwipe != 0 || HorizontalDoubleSwipe != 0;
        }

        protected bool GetIsZoom()
        {
            return Zoom != 0;
        }


        protected override void CacheInput()
        {
            // Queue 0
            IsScreenTap = GetIsScreenTap();
            IsScreenTapDown = GetIsScreenTapDown();
            IsScreenTapUp = GetIsScreenTapUp();
            IsMultipleTouch = GetIsMultipleTouch();
            DeltaTouchPosition = GetDeltaTouchPosition();
            TouchPosition = GetTouchPosition();
            SwipeVector = GetSwipeVector();
            DoubleSwipeVector = GetDoubleSwipeVector();
        
            // Queue 1
            IsTap = GetIsTap();
            IsTapDown = GetIsTapDown();
            IsTapUp = GetIsTapUp();
            
            // Queue 2
            HorizontalSwipe = GetHorizontalSwipe();
            VerticalSwipe = GetVerticalSwipe();
            HorizontalDoubleSwipe = GetHorizontalDoubleSwipe();
            VerticalDoubleSwipe = GetVerticalDoubleSwipe();
            Zoom = GetZoom();
            ZoomPoint = GetZoomPoint();
            Rotation = GetRotation();


            IsZoom = Mathf.Abs(Zoom) > 0;
            IsSwipe = Mathf.Abs(HorizontalSwipe) > 0 || Mathf.Abs(VerticalSwipe) > 0;
            IsDoubleSwipe = Mathf.Abs(HorizontalDoubleSwipe) > 0 || Mathf.Abs(VerticalDoubleSwipe) > 0;
            
            

            //Events
            if (IsTapDown) OnTapDown?.Invoke();
            if (IsTapUp) OnTapUp?.Invoke();
            if (IsScreenTapDown) OnScreenTapDown?.Invoke();
            if (IsScreenTapUp) OnScreenTapUp?.Invoke();
            if (IsSwipe) OnSwipe?.Invoke();
            if (IsDoubleSwipe) OnDoubleSwipe?.Invoke();
            if (IsZoom) OnZoom?.Invoke();
            
            
            //Debug.Log($"FRAME {Time.frameCount}: IsTapDown = {IsTapDown}");
        }


        protected override void LateUpdate()
        {
            base.LateUpdate();
            OldTouchPosition = TouchPosition == Vector2.zero ? OldTouchPosition : TouchPosition;

            if (IsScreenTapDown)
                _tapStart = TouchPosition;

            
            // TODO: Убрать магические константы, вынести в отдельный метод и тд
            if(IsSwipe || IsDoubleSwipe || IsZoom || (IsScreenTap && (_tapStart - TouchPosition).sqrMagnitude > 400))
                WasAnySwipe = true;
            if (IsScreenTapDown || IsScreenTapUp)
                WasAnySwipe = false;
            
        }
    }
    
}

using UnityEngine;
using UnityEngine.Events;

namespace Game.Services
{
    
    /// <summary>
    /// Универсальный контроллер ввода для мобильных устройств и ПК
    /// ============================================
    /// Данный класс и весь сервис ввода был написан очень давно и нуждается в переработке.
    /// </summary>
    public interface IInputController
    {
    
        /// <summary>
        /// Возвращает true, если пользователь удерживает палец на экране 
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        bool IsTap { get; }

        /// <summary>
        /// Возвращает true если пользователь поставил палец на экран.
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        bool IsTapDown { get; }

        /// <summary>
        /// Возвращает true если пользователь убрал палец с экрана.
        /// (Учитываются элементы, блокирующие нажатия, такие, как UI, в таком случае нажатие не засчитывается)
        /// </summary>
        bool IsTapUp { get; }

        /// <summary>
        /// Возвращает true, если пользователь удерживает палец на экране
        /// </summary>
        /// <returns></returns>
        bool IsScreenTap { get; }

        /// <summary>
        /// Возвращает true если пользователь поставил палец на экран.
        /// </summary>
        /// <returns></returns>
        bool IsScreenTapDown { get; }

        /// <summary>
        /// Возвращает true, если пользователь убрал палец с экрана.
        /// </summary>
        /// <returns></returns>
        bool IsScreenTapUp { get; }

        
        /// <summary>
        /// Возвращает true, если пользователь удерживает несколько пальцев на экране
        /// </summary>
        bool IsMultipleTouch { get; }
        
        
        /// <summary>
        /// Возвращает вектор движения пальца влево-вправо, вверх-вниз.
        /// </summary>
        Vector3 DeltaTouchPosition { get; }

        /// <summary>
        /// Возвращает точку нажатия по экрану. При обработке отпускания пальца используейте OldTouchPosition
        /// </summary>
        Vector2 TouchPosition { get; }

        /// <summary>
        /// Возвращает точку нажатия по экрану на прошлом кадре.
        /// Нужно для определения позиции при отпускании пальца
        /// </summary>
        Vector2 OldTouchPosition { get; }

        /// <summary>
        /// Возвращает расстояние горизонтального свайпа
        /// Положительное - вправо
        /// Отрицательное - влево
        /// </summary>
        float HorizontalSwipe { get; }

        /// <summary>
        /// Возвращает расстояние вертикального свайпа
        /// Положительное - вверх
        /// Отрицательное - вниз
        /// </summary>
        float VerticalSwipe { get; }

        /// <summary>
        /// Возвращает расстояние горизонтального свайпа двумя пальцами
        /// Положительное - вправо
        /// Отрицательное - влево
        /// </summary>
        float HorizontalDoubleSwipe { get; }

        /// <summary>
        /// Возвращает расстояние вертикального свайпа двумя пальцами
        /// Положительное - вверх
        /// Отрицательное - вниз
        /// </summary>
        /// <returns></returns>
        float VerticalDoubleSwipe { get; }

        /// <summary>
        /// Возвращает уровень зума (положительный - разведение пальцев, отрицательный - сведение)
        /// </summary>
        /// <returns></returns>
        float Zoom { get; }
        
        /// <summary>
        /// Возвращает позицию точки зума на экране (между двумя пальцами)
        /// </summary>
        /// <returns></returns>
        Vector2 ZoomPoint { get; }

        /// <summary>
        /// Возвращает угол поворота, заданный жестом поворота в текущем кадре
        /// </summary>
        float Rotation { get; }

        /// <summary>
        /// Вектор, показывающий направление свайпа
        /// </summary>
        Vector2 SwipeVector { get; }
        
        /// <summary>
        /// Вектор, показывающий направление двойного свайпа
        /// </summary>
        Vector2 DoubleSwipeVector { get; }

        /// <summary>
        /// Возвращает true, если производится свайп
        /// </summary>
        bool IsSwipe { get; }
        
        /// <summary>
        /// Возвращает true, если производится двойной свайп
        /// </summary>
        bool IsDoubleSwipe { get; }
        
        /// <summary>
        /// Возвращает true, если производится зум
        /// </summary>
        bool IsZoom { get; }


        bool WasAnySwipe { get; }






        UnityEvent OnTapDown { get; }

        UnityEvent OnTapUp { get; }
        
        UnityEvent OnScreenTapDown { get; }

        UnityEvent OnScreenTapUp { get; }

        UnityEvent OnSwipe { get; }
        
        UnityEvent OnDoubleSwipe { get; }

        UnityEvent OnZoom { get; }




        /// <summary>
        /// Заблокировать ввод
        /// </summary>
        void BlockInput();

        /// <summary>
        /// Разблокировать ввод
        /// </summary>
        void UnblockInput();

    }
}

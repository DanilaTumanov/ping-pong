using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class CanvasView : View
    {

        private Canvas _canvas;
        
        protected override void Awake()
        {
            base.Awake();

            _canvas = GetComponent<Canvas>();
        }

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }
    
    }
}

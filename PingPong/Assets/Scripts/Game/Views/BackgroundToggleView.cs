using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class BackgroundToggleView : MonoBehaviour
    {

        [SerializeField] private Image _image;
        [SerializeField] private Toggle _toggle;

        private int _index;
        
        public event Action<int> OnSelected;


        private void Awake()
        {
            _toggle.onValueChanged.AddListener(check =>
            {
                if (check)
                {
                    OnSelected?.Invoke(_index);
                }
            });
        }


        public void Init(int index, Sprite sprite, ToggleGroup toggleGroup)
        {
            _image.sprite = sprite;
            _toggle.group = toggleGroup;
            _index = index;
        }

        public void SetActive(bool isActive)
        {
            _toggle.isOn = isActive;
        }
        
    }
}

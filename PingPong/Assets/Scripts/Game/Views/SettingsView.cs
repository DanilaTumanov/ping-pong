using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class SettingsView : CanvasView
    {

        [SerializeField] private ToggleGroup _backgroundToggleGroup;
        [SerializeField] private BackgroundToggleView _backgroundTogglePrefab;
        [SerializeField] private Button _closeButton;


        public Action<int> OnBackgroundSelected;
        public Action OnCloseButtonPressed;


        protected override void Awake()
        {
            base.Awake();
            
            _closeButton.onClick.AddListener(() => OnCloseButtonPressed?.Invoke());
        }

        public void SetBackgroundsList(List<Sprite> backgroundsList, int activeBackgroundIndex)
        {

            for (int i = 0; i < backgroundsList.Count; i++)
            {
                var toggle = Instantiate(_backgroundTogglePrefab, _backgroundToggleGroup.transform);
                toggle.Init(i, backgroundsList[i], _backgroundToggleGroup);

                if (i == activeBackgroundIndex)
                {
                    toggle.SetActive(true);
                }
                    
                toggle.OnSelected += BackgroundSelectedHandler;
            }
        }


        private void BackgroundSelectedHandler(int index)
        {
            OnBackgroundSelected?.Invoke(index);
        }

    }
}

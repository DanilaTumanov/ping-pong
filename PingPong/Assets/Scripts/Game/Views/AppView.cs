using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;
using Game.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

public class AppView : View
{

    [SerializeField] private StartMenuView _startMenuView;
    [SerializeField] private HudView _hudView;
    //[SerializeField] private GameplayView _gameplayView;


    public void StartGame()
    {
        _startMenuView.Hide();
        _hudView.Show();
    }

    public void StopGame()
    {
        _startMenuView.Show();
        _hudView.Hide();
    }

}

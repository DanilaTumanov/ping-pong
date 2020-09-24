using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;
using Game.Services.InputService;
using Game.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

public class GameplayView : View
{

    [SerializeField] private GameField _gameField;
    [SerializeField] private PlayerView _playerView;

    private PlayerView _player1;
    private PlayerView _player2;
    
    protected override void Start()
    {
        _player1 = Instantiate(_playerView);
        _player2 = Instantiate(_playerView);
        
        _gameField.PlacePlayers(_player1, _player2);
    }
}

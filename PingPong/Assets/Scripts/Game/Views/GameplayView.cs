using System;
using Game.Gameplay;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Views
{
    public class GameplayView : View
    {

        [SerializeField] private GameField _gameField;
        [SerializeField] private Player _playerView;

        private Player _player1;
        private Player _player2;

        public event Action OnOut;

        protected override void Start()
        {
            _player1 = Instantiate(_playerView);
            _player2 = Instantiate(_playerView);
        
            _gameField.PlacePlayers(_player1, _player2);
            
        }

        public void BallInPlay(Ball ball)
        {
            var randomVector = new Vector2(Random.Range(-.5f, .5f), Random.Range(.5f, 1f)) 
                             * (Random.Range(0, 2) - 0.5f);
            
            ball.transform.SetParent(_gameField.transform);
            ball.Go(randomVector.normalized);

            ball.OnBallOut += OutHandler;
        }

        private void OutHandler()
        {
            OnOut?.Invoke();
        }
    
    }
}

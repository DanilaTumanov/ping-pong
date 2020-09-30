using System;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities.Balls;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{
    public class GameplayView : View
    {

        [SerializeField] private GameField _gameField;
        [SerializeField] private Player _playerView;

        private Player _hostPlayer;
        private Player _clientPlayer;

        public event Action OnOut;
        public event Action OnHit;

        protected override void Start()
        {
            _hostPlayer = Instantiate(_playerView);
            _clientPlayer = Instantiate(_playerView);
        
            _gameField.PlacePlayers(_hostPlayer, _clientPlayer);
        }

        public void BallInPlay(Ball ball)
        {
            var randomVector = new Vector2(Random.Range(-.5f, .5f), Random.Range(.5f, 1f)) 
                             * (Random.Range(0, 2) - 0.5f);
            
            ball.transform.SetParent(_gameField.transform);
            ball.Go(randomVector.normalized);

            ball.OnBallOut += OutHandler;
            ball.OnBallHit += HitHandler;
        }

        private void OutHandler()
        {
            OnOut?.Invoke();
        }

        private void HitHandler()
        {
            OnHit?.Invoke();
        }

    }
}

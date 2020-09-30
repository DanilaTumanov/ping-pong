using System;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities.Balls;
using Photon.Pun;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{
    public class GameplayView : View
    {

        [SerializeField] private GameField _gameField;

        public void SetPlayer(Player player, bool isMasterClient)
        {
            if (!isMasterClient)
            {
                Camera.main.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
            }

            _gameField.PlacePlayers(player, isMasterClient);
        }
        
        public void BallInPlay(Ball ball)
        {
            var randomVector = new Vector2(Random.Range(-.5f, .5f), Random.Range(.5f, 1f)) 
                             * (Random.Range(0, 2) - 0.5f);
            
            ball.transform.SetParent(_gameField.transform);
            ball.Init(randomVector.normalized);
        }

    }
}

using System;
using Game.Gameplay.Field;
using Game.Gameplay.GameEntities.Balls;
using Photon.Pun;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{
    
    /// <summary>
    /// Отображение игрового процесса, инициализация и глобальное управление
    /// </summary>
    public class GameplayView : View
    {

        [SerializeField] private GameField _gameField;

        /// <summary>
        /// Разместить игрока на поле
        /// </summary>
        /// <param name="player"></param>
        /// <param name="isMasterClient">Признак главного клиента</param>
        public void SetPlayer(Player player, bool isMasterClient)
        {
            if (!isMasterClient)
            {
                Camera.main.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
            }

            _gameField.PlacePlayer(player, isMasterClient);
        }
        
        
        /// <summary>
        /// ВВести мяч в игру
        /// </summary>
        /// <param name="ball"></param>
        public void BallInPlay(Ball ball)
        {
            var randomVector = new Vector2(Random.Range(-.5f, .5f), Random.Range(.5f, 1f)) 
                             * (Random.Range(0, 2) - 0.5f);
            
            ball.transform.SetParent(_gameField.transform);
            ball.Init(randomVector.normalized);
        }

    }
}

using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using UnityEngine;

namespace Game.Services.ConfigService
{
    [CreateAssetMenu(fileName = "Config", menuName = "Config", order = 1)]
    public class Config : ScriptableObject
    {

        public Ball[] ballsPrefabs;

    }
}

using Game.Gameplay;
using Game.Gameplay.GameEntities;
using Game.Gameplay.GameEntities.Balls;
using UnityEngine;

namespace Game.Services.ConfigService
{
    
    /// <summary>
    /// Файл конфигурации приложения
    /// </summary>
    [CreateAssetMenu(fileName = "Config", menuName = "Config", order = 1)]
    public class Config : ScriptableObject
    {

        public Ball[] ballsPrefabs;

        public Player playerPrefab;

        public string playerPrefabResourceFolder;
        
        public string ballsPrefabsResourceFolder;

        public Sprite[] backgrounds;

        public Vector2 invitationCodesRange;

    }
}

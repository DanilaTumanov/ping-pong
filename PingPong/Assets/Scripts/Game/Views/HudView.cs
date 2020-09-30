using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    
    /// <summary>
    /// Отображение игрового интерфейса
    /// </summary>
    public class HudView : CanvasView
    {

        [SerializeField] private Text _score;
        [SerializeField] private Text _maxScore;
        [SerializeField] private Image _background;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }

        public void SetMaxScore(int maxScore)
        {
            _maxScore.text = maxScore.ToString();
        }

        public void SetBackground(Sprite sprite)
        {
            _background.sprite = sprite;
        }
        
    }
}

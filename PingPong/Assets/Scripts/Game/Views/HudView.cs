using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class HudView : CanvasView
    {

        [SerializeField] private Text _score;
        [SerializeField] private Text _maxScore;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }

        public void SetMaxScore(int maxScore)
        {
            _maxScore.text = maxScore.ToString();
        }
        
    }
}

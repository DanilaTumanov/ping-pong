using Game.Models;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    public class HitCommand : Command
    {
        private readonly IScoresModel _scoresModel;

        public HitCommand(IScoresModel scoresModel)
        {
            _scoresModel = scoresModel;
        }
    
        public override void Execute()
        {
            _scoresModel.Scores.Value += 1;
            _scoresModel.MaxScores.Value = Mathf.Max(_scoresModel.Scores.Value, _scoresModel.MaxScores.Value);
        }
    }
}

using Game.Models;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Commands
{
    public class OutCommand : Command
    {
        private readonly IScoresModel _scoresModel;

        public OutCommand(IScoresModel scoresModel)
        {
            _scoresModel = scoresModel;
        }
        
        public override void Execute()
        {
            _scoresModel.MaxScores.Value = Mathf.Max(_scoresModel.Scores.Value, _scoresModel.MaxScores.Value);
            _scoresModel.Scores.Value = 0;
        }
    }
}

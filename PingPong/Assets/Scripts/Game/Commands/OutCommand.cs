using Game.Models;
using strange.extensions.command.impl;

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
            _scoresModel.Scores.Value = 0;
        }
    }
}

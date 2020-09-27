using Game.Models;
using strange.extensions.command.impl;

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
        }
    }
}

using Game.Services.RuntimeService;
using Game.Services.UserDataService;

namespace Game.Models.Scores
{
    public class ScoresModel: Model, IScoresModel
    {
        
        public ContextProperty<int> Scores { get; } = new ContextProperty<int>();

        [Save] public ContextProperty<int> MaxScores { get; } = new ContextProperty<int>();
        
        
        
        public ScoresModel(IUserDataService userDataService, IRuntimeService runtimeService) : base(userDataService, runtimeService)
        {
        }
    }
}

namespace Game.Models
{
    public interface IScoresModel
    {

        ContextProperty<int> Scores { get; }
        ContextProperty<int> MaxScores { get; }
        
    }
}

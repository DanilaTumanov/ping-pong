namespace Game.Models
{
    
    /// <summary>
    /// Набранные очки
    /// </summary>
    public interface IScoresModel
    {

        ContextProperty<int> Scores { get; }
        ContextProperty<int> MaxScores { get; }
        
    }
}

using System;

public static class ScoreSystem
{
    public static event Action<int> ScoreUpdated;
    
    public static int Score { get; private set; }

    public static void AddScore(int score)
    {
        Score += score;
        ScoreUpdated?.Invoke(Score);
    }

    public static void Refresh()
    {
        Score = 0;
        ScoreUpdated?.Invoke(Score);
    }
}

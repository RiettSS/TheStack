using UnityEngine.SceneManagement;

public class GameRules
{
    private IInputService _inputService;
    private IPlatformCreator _platformCreator;

    public GameRules(IInputService inputService, IPlatformCreator platformCreator)
    {
        _inputService = inputService;
        _platformCreator = platformCreator;

        _inputService.PlayerTapped += OnPlayerTap;
    }

    public void Start()
    {
        ScoreSystem.Refresh();
        _platformCreator.CreatePlatform();
    }

    private void OnPlayerTap()
    {
        if (!Placeable())
        {
            GameOver();
            Platform.CurrentPlatform.Stop();
            return;
        }

        if (PerfectMatch())
        {
            Platform.CurrentPlatform.Stop();
            Platform.CurrentPlatform.AlignToLastPlatform();
            ScoreSystem.AddScore(3);
            _platformCreator.CreatePlatform();
            return;
        }
        
        Platform.CurrentPlatform.Stop();
        Platform.CurrentPlatform.Cut();
        ScoreSystem.AddScore(1);
        _platformCreator.CreatePlatform();
    }

    private bool PerfectMatch()
    {
        return Platform.CurrentPlatform.PerfectMatch();
    }

    private bool Placeable()
    {
        return Platform.CurrentPlatform.Placeable();
    }

    private void GameOver()
    {
        _inputService.PlayerTapped -= OnPlayerTap;
        ShowAd();
        SendScoreToDatabase();
        SceneManager.LoadScene(0);
    }

    private void ShowAd()
    {
        
    }

    private void SendScoreToDatabase()
    {
        
    }
}

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

        if (IdealMatch())
        {
            Platform.CurrentPlatform.Stop();
            Platform.CurrentPlatform.AlignToLastPlatform();
            return;
        }
        
        Platform.CurrentPlatform.Stop();
        Platform.CurrentPlatform.Cut();
        _platformCreator.CreatePlatform();
    }

    private bool IdealMatch()
    {
        return false;
    }

    private bool Placeable()
    {
        return Platform.CurrentPlatform.Placeable();
    }

    private void GameOver()
    {
        _inputService.PlayerTapped -= OnPlayerTap;
        SceneManager.LoadSceneAsync(0);
    }
}

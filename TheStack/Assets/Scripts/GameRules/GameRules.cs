using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules
{
    private IInputService _inputService;
    private IPlatformCreator _platformCreator;

    private Camera _mainCamera;
    private int _platformCounter;

    public GameRules(IInputService inputService, IPlatformCreator platformCreator)
    {
        _inputService = inputService;
        _platformCreator = platformCreator;

        _inputService.PlayerTapped += OnPlayerTap;
    }

    public void Start()
    {
        ScoreSystem.Refresh();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mainCamera.backgroundColor = GetOppositeColor();
        _platformCreator.CreatePlatform(GetColor());
    }

    private void OnPlayerTap()
    {
        if (!Placeable())
        {
            GameOver();
            Platform.CurrentPlatform.Stop();
            return;
        }

        _platformCounter += 1;

        if (PerfectMatch())
        {
            Platform.CurrentPlatform.Stop();
            Platform.CurrentPlatform.AlignToLastPlatform();
            ScoreSystem.AddScore(3);
        }
        else
        {
            Platform.CurrentPlatform.Stop();
            Platform.CurrentPlatform.Cut();
            ScoreSystem.AddScore(1);
        }

        _platformCreator.CreatePlatform(GetColor());
        _mainCamera.backgroundColor = GetOppositeColor();
        _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + Platform.LastPlatform.Thickness, _mainCamera.transform.position.z);
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

    public Color GetColor()
    {
        var offset = _platformCounter * 0.1f;
        var offsetSin = Mathf.Abs(Mathf.Sin(offset)) * 0.95f;
        return new Color(offsetSin, offsetSin, offsetSin);
    }

    private Color GetOppositeColor()
    {
        var color = GetColor();

        var r = 1f - color.r;
        var g = 1f - color.g;
        var b = 1f - color.b;

        var result = new Color(r, g, b);

        return result;
    }
}

using Ads;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules
{
    private IInputService _inputService;
    private IPlatformCreator _platformCreator;
    private ColorGenerator _colorGenerator;
    private InterAd _interAd;

    private Camera _mainCamera;
    private int _platformCounter;

    public GameRules(IInputService inputService, IPlatformCreator platformCreator)
    {
        _inputService = inputService;
        _platformCreator = platformCreator;
        _colorGenerator = new ColorGenerator();
        _interAd = new InterAd();

        _inputService.PlayerTapped += OnPlayerTap;
        _interAd.Closed += RestartGame;
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
        var desiredCameraPosition = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + Platform.LastPlatform.Thickness, _mainCamera.transform.position.z);
        var camera = _mainCamera.GetComponent<CameraController>();
        camera.SetNewPosition(desiredCameraPosition);
        camera.SetNewColor(GetOppositeColor());
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
    }

    private void ShowAd()
    {
        _interAd.Show();
    }

    private void SendScoreToDatabase()
    {

    }

    private void RestartGame()
    {
        _interAd.Closed -= RestartGame;
        SceneManager.LoadScene(0);
    }
    
    public Color GetColor()
    {
        return _colorGenerator.GetColor();
    }

    private Color GetOppositeColor()
    {
        return _colorGenerator.GetOppositeColor();
    }
}

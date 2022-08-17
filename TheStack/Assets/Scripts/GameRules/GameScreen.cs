using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    
    private IInputService _inputService;
    private IPlatformCreator _platformCreator;

    private GameRules _gameRules;

    private void Awake()
    {
        _inputService = GetComponent<IInputService>();
        _platformCreator = GetComponent<IPlatformCreator>();

        _gameRules = new GameRules(_inputService, _platformCreator);
    }

    private void OnEnable()
    {
        ScoreSystem.ScoreUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        ScoreSystem.ScoreUpdated -= UpdateUI;
    }

    private void Start()
    {
        _gameRules.Start();
    }

    private void UpdateUI(int score)
    {
        _scoreText.text = score.ToString();
        _scoreText.color = _gameRules.GetColor();
    }
}

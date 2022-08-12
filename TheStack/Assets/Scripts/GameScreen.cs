using System;
using UnityEditor;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    private IInputService _inputService;
    private IPlatformCreator _platformCreator;

    private GameRules _gameRules;

    private void Awake()
    {
        _inputService = GetComponent<IInputService>();
        _platformCreator = GetComponent<IPlatformCreator>();

        _gameRules = new GameRules(_inputService, _platformCreator);
    }

    private void Start()
    {
        _gameRules.Start();
    }
}

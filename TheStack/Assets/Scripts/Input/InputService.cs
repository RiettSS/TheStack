using System;
using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    public event Action PlayerTapped;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerTapped?.Invoke();
        }
    }
}

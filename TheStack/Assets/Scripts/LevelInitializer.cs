using System;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    private void Awake()
    {
        Platform.LastPlatform = GetComponent<Platform>();
    }
}

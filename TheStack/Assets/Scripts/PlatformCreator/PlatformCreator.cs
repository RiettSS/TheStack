using UnityEngine;

public class PlatformCreator : MonoBehaviour, IPlatformCreator
{
    private IPlatformFabric _platformFabric;

    private void Awake()
    {
        _platformFabric = GetComponent<IPlatformFabric>();
    }

    public Platform CreatePlatform(Color color)
    {
        var platform = _platformFabric.CreatePlatform();
        
        platform.Speed = 1.5f;
        Platform.CurrentPlatform = platform;
        platform.ChangeColor(color);
        
        return platform;
    }
}

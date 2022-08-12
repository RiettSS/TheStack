using UnityEngine;

public class PlatformCreator : MonoBehaviour, IPlatformCreator
{
    private IPlatformFabric _platformFabric;

    private void Awake()
    {
        _platformFabric = GetComponent<IPlatformFabric>();
    }

    public Platform CreatePlatform()
    {
        var platform = _platformFabric.CreatePlatform();
        
        platform.Speed = 1.5f;
        Platform.CurrentPlatform = platform;
        
        return platform;
    }
}

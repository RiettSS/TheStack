using UnityEngine;

public class PlatformFabric : MonoBehaviour, IPlatformFabric
{
    [SerializeField] private GameObject _platformPrefab;

    private int _platformCounter;
    
    public Platform CreatePlatform()
    {
        var platformInstance = Instantiate(_platformPrefab);

        if (_platformCounter % 2 == 0)
            platformInstance.AddComponent<LeftPlatform>();
        else
            platformInstance.AddComponent<RightPlatform>();

        platformInstance.transform.position = new Vector3(transform.position.x, transform.position.y + (0.1f * _platformCounter));
        platformInstance.transform.localScale = new Vector3(Platform.LastPlatform.transform.localScale.x, 0.1f, Platform.LastPlatform.transform.localScale.z);

        _platformCounter++;

        var platform = platformInstance.GetComponent<Platform>();
        platform.ChangeColor(GetColor());
        
        return platform;
    }

    private Color GetColor()
    {
        var offset = _platformCounter * 0.1f;

        var offsetSin = Mathf.Abs(Mathf.Sin(offset));
        
        
        return new Color(offsetSin, offsetSin, offsetSin);
    }
}

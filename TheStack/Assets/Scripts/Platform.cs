using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    public float Thickness { get; private set; }
    
    [SerializeField] public float Speed;
    
    public static Platform CurrentPlatform;
    public static Platform LastPlatform;

    private float _movingOffset;
    private float _startPoint = -1.8f;

    private bool _isStopped = false;

    private void Awake()
    {
        Thickness = transform.localScale.y;
        _movingOffset -= _startPoint;
        Thickness = 0.1f;
    }

    public void Stop()
    {
        _isStopped = true;
    }

    public void AlignToLastPlatform()
    {
        var lastPlatformPosition = LastPlatform.transform.position;
        var desiredPosition = new Vector3(LastPlatform.transform.position.x, CurrentPlatform.transform.position.y, LastPlatform.transform.position.z);

        CurrentPlatform.transform.position = desiredPosition;
    }

    public void ChangeColor(Color color)
    {
        GetComponentInChildren<Renderer>().material.color = color;
    }

    public abstract void Cut();
    
    public abstract bool Placeable();

    protected abstract void Move(float position);

    protected void Place()
    {
        _isStopped = true;
        LastPlatform = this;
    }
    
    private void Update()
    {
        _movingOffset += Time.deltaTime * Speed;
        var position = Mathf.Sin(_movingOffset) * 1.5f;

        if(!_isStopped)
            Move(position);
    }

    public bool PerfectMatch()
    {
        var currentPlatformPosition = CurrentPlatform.transform.position;
        var lastPlatformPosition = LastPlatform.transform.position;
        var positionsDelta = currentPlatformPosition - lastPlatformPosition;
        var perfectMatchCondition = 0.3f;

        Debug.Log(positionsDelta.magnitude < perfectMatchCondition);
        
        return positionsDelta.magnitude < perfectMatchCondition;
    }
}

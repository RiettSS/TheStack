using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] public float Speed;

    public static Platform CurrentPlatform;
    public static Platform LastPlatform;

    private float _movingOffset;
    private float _thickness;
    private float _startPoint = -1.8f;

    private bool _isStopped = false;

    private void Awake()
    {
        _thickness = transform.localScale.y;
        _movingOffset -= _startPoint;
    }

    public void Stop()
    {
        _isStopped = true;
    }

    public void AlignToLastPlatform()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeColor(Color color)
    {
        throw new System.NotImplementedException();
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
}

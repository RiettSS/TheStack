using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _desiredPosition;
    private Vector3 _desiredColor;

    [SerializeField]private Camera _camera;

    private void Awake()
    {
        _desiredPosition = transform.position;
        _desiredColor = new Vector3(_camera.backgroundColor.r, _camera.backgroundColor.g, _camera.backgroundColor.b);
    }

    public void SetNewPosition(Vector3 desiredCameraPosition)
    {
        _desiredPosition = desiredCameraPosition;
    }

    public void SetNewColor(Color color)
    {
        _desiredColor = _desiredColor = new Vector3(color.r, color.g, color.b);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _desiredPosition, 0.01f);
        var currentColor = new Vector3(_camera.backgroundColor.r, _camera.backgroundColor.g, _camera.backgroundColor.b);
        var tempColor = Vector3.Lerp(currentColor, _desiredColor, 0.01f);

        _camera.backgroundColor = new Color(tempColor.x, tempColor.y, tempColor.z);
    }
}

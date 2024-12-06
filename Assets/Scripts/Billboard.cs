using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private BillboardType billboardType;
    private enum BillboardType { LookAtCamera, CameraForward }
    
    private Transform _camera;
    
    void Start()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:  // Face to camera.
                transform.LookAt(_camera.position);
                break;
            case BillboardType.CameraForward:  // Face to the plane of camera.
                transform.forward = _camera.forward;
                break;
            default:
                break;
        }
    }
}

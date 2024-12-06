using UnityEditorInternal;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform player;
    
    private Inputs _inputs;

    void Start()
    {
        // Setup camera position.
        camera.position = new Vector3(0f, 0f, -cameraZOffset);
        
        // Setup camera rotation.
        anglePerStep = 360.0f / stepsPerRotation;
    }
    
    void Update()
    {
        GatherInput();
        
        HandlePosition();
        HandleRotation();
    }

    private void GatherInput()
    {
        _inputs.RightArrowHeld = Input.GetKey(KeyCode.RightArrow);
        _inputs.LeftArrowHeld = Input.GetKey(KeyCode.LeftArrow);
        _inputs.RightArrowDown = Input.GetKeyDown(KeyCode.RightArrow);
        _inputs.LeftArrowDown = Input.GetKeyDown(KeyCode.LeftArrow);

        if (_inputs.RightArrowDown) rightRotateToConsume = true;
        if (_inputs.LeftArrowDown) leftRotateToConsumue = true;
    }

#region Position

    [Header("Position")]
    [SerializeField] private float heightOffset = 3.5f; 
    [SerializeField] private float cameraZOffset = 3.0f;
    [SerializeField] private float speedFactor = 6.0f;
    
    private void HandlePosition()
    {
        Vector3 targetPosition = player.transform.position + new Vector3(0, heightOffset, 0);
        transform.position += (targetPosition - transform.position) / speedFactor * Time.deltaTime;
    }
    
#endregion

#region Rotation

    [Header("Rotation")]
    [SerializeField] [Range(0.0f, 90.0f)] private float elevationAngle = 30.0f;
    [SerializeField] private float rotateSpeedFactor = 15.0f;
    [SerializeField] private int stepsPerRotation = 6;
    private float anglePerStep = 0.0f;
    private float _targetYAngle = 0.0f;
    private float _actualYAngle = 0.0f;

    private bool rightRotateToConsume = false;
    private bool leftRotateToConsumue = false;
    
    private void HandleRotation()
    {
        if (rightRotateToConsume) _targetYAngle -= anglePerStep;
        if (leftRotateToConsumue) _targetYAngle += anglePerStep;
        rightRotateToConsume = false;
        leftRotateToConsumue = false;
        
        _actualYAngle = Mathf.LerpAngle(_actualYAngle, _targetYAngle, rotateSpeedFactor * Time.deltaTime);
        Vector3 angle = new Vector3(elevationAngle, _actualYAngle, 0.0f);
        
        transform.eulerAngles = angle;
    }

#endregion

    struct Inputs
    {
        public bool RightArrowHeld;
        public bool LeftArrowHeld;
        public bool RightArrowDown;
        public bool LeftArrowDown;
    }
}

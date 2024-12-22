using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform UI;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        _inputs.x = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        _inputs.y = (Input.GetKey(KeyCode.S) ? -1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);
    }

    void FixedUpdate()
    {
        UpdateRotation();
        HandleMovement();
    }
    
#region Rotation

    private float _yRotation;  // radian.

    private void UpdateRotation()
    {
        _yRotation = Mathf.Deg2Rad * UI.eulerAngles.y;
    }

#endregion
    
    
#region Run

    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float velPower;
    
    private Vector2 _inputs;
    
    private void HandleMovement()
    {
        Vector2 normalizedInputs = _inputs.normalized;
        Vector2 rotatedInput =
            new Vector2(Mathf.Cos(_yRotation) * normalizedInputs.x + Mathf.Sin(_yRotation) * normalizedInputs.y,
                - Mathf.Sin(_yRotation) * normalizedInputs.x + Mathf.Cos(_yRotation) * normalizedInputs.y);
        Vector3 targetSpeed = new Vector3(rotatedInput.x * maxSpeed, 0.0f, rotatedInput.y * maxSpeed);
        Vector3 speedDiff = new Vector3(targetSpeed.x - rb.velocity.x, 0.0f, targetSpeed.z - rb.velocity.z);
        Vector3 accelRate = new Vector3(Mathf.Abs(speedDiff.x) > 0.01f ? acceleration : deceleration, 0.0f, 
            Mathf.Abs(speedDiff.z) > 0.01f ? acceleration : deceleration);
        Vector3 movement = new Vector3(
            Mathf.Pow(Mathf.Abs(speedDiff.x) * accelRate.x, velPower) * Mathf.Sign(speedDiff.x), 0.0f,
            Mathf.Pow(Mathf.Abs(speedDiff.z) * accelRate.z, velPower) * Mathf.Sign(speedDiff.z));
        
        rb.AddForce(movement);
    }

#endregion
    
}

using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody _rb;

    public float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // _speed = Mathf.Pow(_rb.velocity.x, 2) + Mathf.Pow(_rb.velocity.z, 2);
        // animator.SetFloat("Speed", _speed / 15.0f);
    }
}

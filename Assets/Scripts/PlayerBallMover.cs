using UnityEngine;

public class PlayerBallMover : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    [SerializeField] private float _moveForce = 14f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody _rigidbodyComponent;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _isGrounded = true;

    private void Awake()
    {
        if (_rigidbodyComponent == null)
        {
            _rigidbodyComponent = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        _verticalInput = Input.GetAxisRaw(_verticalAxis);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbodyComponent.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        _rigidbodyComponent.AddForce(movementDirection * _moveForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
}
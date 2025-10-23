using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _tiltSpeedDegreesPerSecond = 120f; 
    [SerializeField] private Rigidbody _platformRigidbody;          

    private float _pitchDegrees;
    private float _rollDegrees;

    private void Awake()
    {
        if (_platformRigidbody == null)
        {
            _platformRigidbody = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _pitchDegrees += vertical   * _tiltSpeedDegreesPerSecond * Time.fixedDeltaTime;
        _rollDegrees  -= horizontal * _tiltSpeedDegreesPerSecond * Time.fixedDeltaTime;
        
        Quaternion rotation = Quaternion.Euler(_pitchDegrees, 0f, _rollDegrees);
        _platformRigidbody.MoveRotation(rotation);
    }
}
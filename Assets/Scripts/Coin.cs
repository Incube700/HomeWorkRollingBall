using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    [SerializeField] private float _rotateSpeed = 180f;
    [SerializeField] private Rigidbody _ballRigidbody;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        if (_ballRigidbody == null)
        {
            var ball = FindObjectOfType<PlayerBallMover>();
            if (ball != null)
            {
                _ballRigidbody = ball.GetComponent<Rigidbody>();
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != _ballRigidbody)
        {
            return;
        }

        _gameManager.RegisterCoinPickup(_value);

        gameObject.SetActive(false);
    }
}
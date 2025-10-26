using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoinWallet _wallet;   
    [SerializeField] private Coin[] _coins;       
    
    [SerializeField] private float _timeLimitSeconds = 30f;

    private int _totalCoins;
    private float _timeLeft;
    private bool _isRunning;
    private int _lastCoinCount;
    private float _logTimer;

    public bool IsRunning => _isRunning;
    
    private void Start()
    {
        if (_wallet != null)
        {
            _wallet.Clear(); 
        }
        StartGame();
    }

    private void Update()
    {
        if (_isRunning == false)
        {
            return;
        }

        TickTimer();
        
        if (_wallet != null && _wallet.Coins != _lastCoinCount)
        {
            _lastCoinCount = _wallet.Coins;
            CheckWin(_lastCoinCount);
        }
    }
    
    private void StartGame()
    {
        _timeLeft  = _timeLimitSeconds;
        _isRunning = true;
        _lastCoinCount = _wallet != null ? _wallet.Coins : 0;
        _totalCoins = _coins != null ? _coins.Length : 0;
       
        Debug.Log($"Старт. Нужно собрать {_totalCoins} монет за {_timeLimitSeconds} сек.");
    }

    private void TickTimer()
    {
        _timeLeft -= Time.deltaTime;
        
        _logTimer += Time.deltaTime;
        if (_logTimer >= 0.5f)
        {
            _logTimer = 0f;
            Debug.Log($"Осталось: {_timeLeft:0.0} сек.");
        }

        if (_timeLeft <= 0f)
        {
            HandleLose();
        }
    }

    private void CheckWin(int collected)
    {
        if (collected >= _totalCoins)
        {
            HandleWin();
        }
    }

    private void HandleWin()
    {
        if (_isRunning == false) return;
        _isRunning = false;
        Debug.Log("Победа! Все монеты собраны.");
    }

    private void HandleLose()
    {
        if (_isRunning == false) return;
        _isRunning = false;
        Debug.Log("Поражение. Время вышло.");
    }
}

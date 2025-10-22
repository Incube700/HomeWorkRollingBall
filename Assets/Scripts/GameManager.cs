
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _limitSeconds = 60f;

    private int _totalCoins;
    private int _collectedCoins;
    private int _score;
    private float _timeLeft;
    private bool _isRunning;

    private void Start()
    {
        _totalCoins = FindObjectsOfType<Coin>().Length;
        _timeLeft = _limitSeconds;
        _isRunning = true;

        Debug.Log($"Игра началась! Собрано монет: {_totalCoins}. Время {_limitSeconds} cек.");
    }

    private void Update()
    {
        if (_isRunning == false) return;

        _timeLeft -= Time.deltaTime;
        Debug.Log($"Осталось времени: {_timeLeft:0.00} сек");

        if (_timeLeft <= 0)
        {
            _isRunning = false;
            CheckWinOrLose();
        }
    }

    public void RegisterCoinPickup(int value)
    {
        if (_isRunning == false) return;

        _collectedCoins += 1;
        _score += value;

        Debug.Log($"Собрано: {_collectedCoins}/{_totalCoins}. Очки: {_score}");

        if (_collectedCoins >= _totalCoins)
        {
            _isRunning = false;
            CheckWinOrLose();
        }
    }

    private void CheckWinOrLose()
    {
        if (_collectedCoins >= _totalCoins)
            Debug.Log($"Победа! Собраны все монеты! Очки: {_score}");
        else
            Debug.Log($"Поражение. Очки: {_score}");
    }
}
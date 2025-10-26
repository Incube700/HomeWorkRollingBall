using UnityEngine;

namespace DefaultNamespace
{
    public class CoinInteractor : MonoBehaviour
    {
        [SerializeField] private CoinWallet _wallet;
        
        private void OnTriggerEnter(Collider other)
        {
            var coin = other.GetComponent<Coin>();
            if (coin == null)
            {
                return;
            }

            _wallet.AddCoins(coin.Value);
            coin.Collect();
        }
    }
}
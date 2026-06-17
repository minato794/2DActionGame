using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int coinCount = 0;
    public TMP_Text coinText;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "Coin: " + coinCount;
    }
}
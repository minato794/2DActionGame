using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultUIManager : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        coinText.text = "Coin: " + CoinManager.instance.coinCount;
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage2Scene");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
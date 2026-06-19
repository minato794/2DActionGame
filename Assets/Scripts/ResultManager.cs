using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultUIManager : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        coinText.text = "Coin: " + GameData.coinCount;
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage2Scene");
    }

    public void BackToTitle()
    {
      //  Debug.Log("タイトルボタン押された！");
        SceneManager.LoadScene("TitleScene");
    }
}
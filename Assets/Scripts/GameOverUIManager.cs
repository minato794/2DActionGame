using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(GameData.retrySceneName);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
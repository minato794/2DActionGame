using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public AudioClip gameOverSE;
    public AudioClip stompSE;
    public AudioSource bgmSource;

    private bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        // -------------------------
        // 踏みつけ判定
        // -------------------------
        if (collision.transform.position.y > transform.position.y + 0.3f)
        {
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 8f);
            }

            if (stompSE != null)
            {
                AudioSource.PlayClipAtPoint(
                    stompSE,
                    Camera.main.transform.position,
                    1f
                );
            }

            Destroy(gameObject);
            return;
        }

        // -------------------------
        // ゲームオーバー処理
        // -------------------------
        if (isGameOver) return;

        isGameOver = true;

        // スクロール停止
        StageScroll.isStop = true;

        // プレイヤー停止
        Player playerScript = collision.gameObject.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.enabled = false;
        }

        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector2.zero;
            playerRb.simulated = false;
        }

        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }

        if (gameOverSE != null)
        {
            AudioSource.PlayClipAtPoint(
                gameOverSE,
                transform.position
            );
        }

        yield return new WaitForSeconds(1.5f);

        // 現在のステージ名を保存
        GameData.retrySceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene("GameOverScene");
    }
}
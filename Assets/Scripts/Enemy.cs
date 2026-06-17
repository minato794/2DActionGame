using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public AudioClip gameOverSE;
    public AudioSource bgmSource;

    private bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver && collision.gameObject.CompareTag("Player"))
        {
            isGameOver = true;

            // 全敵停止
            EnemyMove.gameOver = true;

            // プレイヤーの移動スクリプトを停止
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.enabled = false;
            }

            // プレイヤーの移動を停止
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }

        AudioSource.PlayClipAtPoint(gameOverSE, transform.position);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOverScene");
    }
}
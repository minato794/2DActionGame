using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{
    public AudioSource goalSE;
    public AudioSource bgm;

    private bool cleared = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cleared) return;

        if (other.CompareTag("Player"))
        {
            cleared = true;

            // ★スクロール停止
            StageScroll.isStop = true;

            if (bgm != null)
            {
                bgm.Stop();
            }

            // プレイヤー停止
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.enabled = false;
            }

            StartCoroutine(GoalClear());
        }
    }

    IEnumerator GoalClear()
    {
        if (goalSE != null)
        {
            goalSE.Play();
        }

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GoalScene");
    }
}
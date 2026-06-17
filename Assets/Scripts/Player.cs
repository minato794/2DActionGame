using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float jumpForce = 7f;
    public float speed = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isGameOver = false;

    [Header("Audio")]
    public AudioClip gameOverSE;
    public AudioSource bgmSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isGameOver) return;

        // 落下ゲームオーバー
        if (transform.position.y < -10f)
        {
            StartGameOver();
        }

        // 地面判定
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            0.2f,
            groundLayer
        );

        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector3 move = Vector3.zero;

        if (keyboard.aKey.isPressed)
        {
            move = Vector3.left;
            spriteRenderer.flipX = true;
        }
        else if (keyboard.dKey.isPressed)
        {
            move = Vector3.right;
            spriteRenderer.flipX = false;
        }

        // ★元の移動方式（transform）
        transform.Translate(move * speed * Time.deltaTime);

        // ジャンプ
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void StartGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        StageScroll.isStop = true;

        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;

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
            AudioSource.PlayClipAtPoint(gameOverSE, transform.position);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOverScene");
    }
}
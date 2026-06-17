using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;
using System.Net;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    int life = 3;


    private Rigidbody2D rb;
    public float jumpForce = 7f;
    private float moveInput;
    private SpriteRenderer spriteRenderer;
    public float speed = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per fram


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // キーボードの状態を直接見に行く最新の書き方
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector3 move = Vector3.zero;

        if (keyboard.aKey.isPressed)
        {
            move = Vector3.left; // 左方向 (-1, 0, 0)
            spriteRenderer.flipX = true;
        }
        else if (keyboard.dKey.isPressed)
        {
            move = Vector3.right; // 右方向 (1, 0, 0)
            spriteRenderer.flipX = false;
        }

        // Time.deltaTime を掛けることで、PCの性能に関わらず一定の速度になります
        transform.Translate(move * speed * Time.deltaTime);

        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    float lastDamageTime; // 最後にダメージを受けた時間
    float damageInterval = 1.0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Time.time > lastDamageTime + damageInterval)
            {
                // 相手の名前をログに表示
                Debug.Log(collision.gameObject.name + "に当たった！");
                lastDamageTime = Time.time;
                life -= 1;

            }
        }


    }
}
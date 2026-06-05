using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 5f;

   // [Header("ジャンプ設定")]
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左右の入力を取得（A/Dキー、矢印キー）
       /* horizontalInput = Input.GetAxisRaw("Horizontal");

        // 地面に接地しているか判定（足元の小さな円の範囲に地面レイヤーがあるか）
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // 地面にいて、スペースキーが押されたらジャンプ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.X, jumpForce);
        }*/
    }
}

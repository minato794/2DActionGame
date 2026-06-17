using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static bool gameOver = false;

    public float speed = 2f;
    private int direction = 1;

    void Update()
    {
        if (gameOver) return;

        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            direction *= -1;
        }
    }
}
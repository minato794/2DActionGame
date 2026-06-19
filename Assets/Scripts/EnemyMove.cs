using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;

    void Update()
    {
        if (StageScroll.isStop) return;

        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            direction *= -1;
        }
    }
}
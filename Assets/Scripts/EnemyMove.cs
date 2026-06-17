using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}
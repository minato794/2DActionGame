using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(
                coinSE,
                Camera.main.transform.position
            );

            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // SE再生
            AudioSource.PlayClipAtPoint(
                coinSE,
                Camera.main.transform.position
            );

            // コイン加算
            CoinManager.instance.AddCoin(1);

            // コイン削除
            Destroy(gameObject);
        }
    }
}
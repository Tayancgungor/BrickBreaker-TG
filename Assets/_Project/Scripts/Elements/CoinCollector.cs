using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public Player player;
    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.gameObject.CompareTag("Coin"))
        {
            player.CoinCollected();
            Destroy(collision.gameObject);
        }
    }

}

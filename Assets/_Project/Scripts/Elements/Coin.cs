using UnityEditor.VersionControl;
using UnityEngine;

public class Coin : MonoBehaviour

{
    public CoinManager coinManager;
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
            Debug.Log("Coin Destroyed");
        }

    }
}
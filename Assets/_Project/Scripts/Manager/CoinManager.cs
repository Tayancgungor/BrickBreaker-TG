using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoinManager : MonoBehaviour
{
    public CoinUI CoinUI;
     void Start()
    {
       Physics2D.IgnoreLayerCollision(
       LayerMask.NameToLayer("Coin"),
       LayerMask.NameToLayer("Brick")
   );
    }
    public Coin coinPrefab;
    public int coinCount;

    private Coroutine _coinSpawnCoroutine;

    public void StartCoinSpawnCoroutine()
    {
        StopCoinSpawnCoroutine();
        _coinSpawnCoroutine = StartCoroutine(CoinSpawnCoroutine());

    }

    IEnumerator CoinSpawnCoroutine()
    {
        while (true)
        {
            var spawnTime = Random.Range(3f, 6f);
            var spawnPos = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(0, 4.3f), 0);
            yield return new WaitForSeconds(spawnTime);
            CreateCoinAtPosition(spawnPos);
        }

    }

    public void StopCoinSpawnCoroutine()
    {
        if (_coinSpawnCoroutine != null)
        {
            StopCoroutine(_coinSpawnCoroutine);
            _coinSpawnCoroutine = null;
        }
    }

    public void CreateCoinAtPosition (Vector3 pos)
    {
        var newCoin = Instantiate(coinPrefab);
        newCoin.transform.position = pos;
        newCoin.transform.localScale = Vector3.zero;
        newCoin.transform.DOScale(1, 2f).SetEase(Ease.OutElastic);

    }
}

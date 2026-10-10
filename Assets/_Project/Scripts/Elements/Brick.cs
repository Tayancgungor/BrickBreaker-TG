using DG.Tweening;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private TextMeshPro healthTMP;
    [SerializeField] private int starthealth;
    [SerializeField] SpriteRenderer sr;


    private int _currentHealth;

    public void StartBrick()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1, .2f).SetEase(Ease.OutBack);
        _currentHealth = starthealth;
    }


    public void GetHit()
    {
        PlayHitFX();
        _currentHealth--;
        healthTMP.text = _currentHealth.ToString();
        if (_currentHealth <= 0)
        {
            DestroyBricks();
        }
    }

    private void OnDestroy()
    {
        sr.transform.DOKill();
        healthTMP.transform.DOKill();
        healthTMP.DOKill();
    }

    void PlayHitFX()
    {
        sr.transform.DOKill();
        sr.transform.localScale = new Vector3(1,.5f,.5f);
        sr.transform.DOScale(new Vector3(1, .5f, .5f) * 1.5f, .1f).SetLoops(2, LoopType.Yoyo);

        healthTMP.transform.DOKill();
        healthTMP.transform.DOScale(1.5f, .1f).SetLoops(2, LoopType.Yoyo);
        healthTMP.transform.localScale = Vector3.one;

        healthTMP.DOKill();
        healthTMP.color = Color.white;
        healthTMP.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);

    }

    private void DestroyBricks()
    {
        GetComponentInParent<BrickManager>().BrickDestroyed(this);
        Destroy(gameObject);
    }
}

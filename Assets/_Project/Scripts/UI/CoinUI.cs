using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinTMP;
    public void Show(int levelNo)
    {
        gameObject.SetActive(true);
        
    }

    public void UpdateCoinCount(int coinCount)
    {
        coinTMP.text = coinCount.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

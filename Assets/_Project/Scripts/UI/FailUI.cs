using UnityEngine;

public class FailUI : MonoBehaviour
{

    public void Show()
    {
        Invoke(nameof(SetActiveTrue), 1.5f);
    }

    void SetActiveTrue()
    {
        gameObject.SetActive(true);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

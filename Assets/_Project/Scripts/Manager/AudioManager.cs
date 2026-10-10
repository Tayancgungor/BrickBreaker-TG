using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ballImpactAS;
    [SerializeField] private AudioSource enemyHitAS;
    [SerializeField] private AudioSource musicAS1;
    [SerializeField] private AudioSource musicAS2;

    public void PlayBallImpactAS()

    {
        ballImpactAS.Play();
    }

    public void PlayEnemyHitAS()
    {
        enemyHitAS.Play();
    }

    public void StartMusic()
    {
        if (Random.value < 0.5f)
        {
            musicAS1.Play();
        }


        else
        {
            musicAS2.Play();
        }
    }

    public void StopMusic()
    {
        musicAS1.Stop();

        musicAS2.Stop();
}

}

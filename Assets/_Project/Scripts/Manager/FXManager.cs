using DG.Tweening;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private float cameraShakeDuration;
    [SerializeField] private float cameraShakeMagnitude;

    [SerializeField] private ParticleSystem ballImpactPSPrefab;
    [SerializeField] private ParticleSystem brickDestroyedPSPrefab;

    [SerializeField] private Camera mainCamera;



    public void PlayBallImpactFX(Vector3 pos, Vector3 direction)
    {
        var newPs = Instantiate(ballImpactPSPrefab, transform);
        newPs.transform.position = pos;
        newPs.transform.LookAt(pos + direction);
        newPs.Play();
    }

    public void PlaybrickDestroyedPS(Vector3 pos)
    {
        var newPs = Instantiate(brickDestroyedPSPrefab, transform);
        newPs.transform.position = pos;
        newPs.Play();
        ShakeCamera();
    }

    private void ShakeCamera()
    {
        mainCamera.transform.DOShakePosition(cameraShakeDuration, cameraShakeMagnitude, 100);
    }
}       



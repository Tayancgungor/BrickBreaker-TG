using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public AudioManager audioManager;
    public FXManager fxManager;

    [SerializeField] private Ball ballPrefab;

    private List<Ball> _balls = new List<Ball>();
    public void RestartBallManager()
    {
        DestroyOldBalls();

        CreateNewBall();
    }

    private void CreateNewBall()
    {
        var newBall = Instantiate(ballPrefab, transform);
        newBall.transform.position = new Vector3(0, -2, 0);

        _balls.Add(newBall);
    }

    public void DestroyOldBalls()
    {
        foreach (var b in _balls)
        {
            Destroy(b.gameObject);
        }
        _balls.Clear();
    }
    public void BallDestroyed(Ball ball)
    {
        _balls.Remove(ball);

        if (_balls.Count == 0)
        {
            gameDirector.LevelFailed();
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class GameDirector : MonoBehaviour
{
    public GameState gameState;

    public LevelManager levelManager;
    public BrickManager brickManager;
    public BallManager ballManager;
    public UIManager uiManager;
    public AudioManager audioManager;
    public FXManager fxManager;
    public CoinManager coinManager;



    public Player player;


    void Start()
    {
        gameState = GameState.MainMenu;
        uiManager.ShowMainMenu();
     

    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
                levelManager.levelNo--;
                RestartLevel();
        }
     
 }

    public void RestartLevel()
    {
        var state = Random.state;
        Random.InitState(levelManager.levelNo+1);

        gameState = GameState.GamePlay;

        levelManager.RestartLevelManager();
        brickManager.RestartBrickManager(levelManager.levelNo);
        player.RestartPlayer();
        ballManager.RestartBallManager();

        audioManager.StopMusic();
        audioManager.StartMusic();

        uiManager.ShowInGameUI(levelManager.levelNo, player.coinCount);

        Random.state = state;

        coinManager.StartCoinSpawnCoroutine();
    }

    public void LevelCompleted()
    {
        gameState = GameState.WinUI;

        ballManager.DestroyOldBalls();
        uiManager.ShowVictoryUI();
        audioManager.StopMusic();
        coinManager.StopCoinSpawnCoroutine();



    }

    public void LevelFailed()

    {
        gameState = GameState.FailUI;
        uiManager.ShowFailUI();
        audioManager.StopMusic();
        coinManager.StopCoinSpawnCoroutine();
    }

    public void LoadNextLevel()
    {
        levelManager.levelNo++;
        RestartLevel();
    }
}


public enum GameState
{
    MainMenu,
    GamePlay,
    WinUI,
    FailUI,
}
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public MainMenu mainMenu;
    public WinUI winUI;
    public FailUI failUI;
    public LevelUI levelUI;
    public CoinUI coinUI;


    public void ShowMainMenu()
    { 
        mainMenu.Show();
        winUI.Hide();
        failUI.Hide();
        HideInGameUI();

    }

    public void ShowVictoryUI()

    {
        winUI.Show();
        mainMenu.Hide();
        failUI.Hide();
        HideInGameUI();
       
    }

    public void ShowFailUI()
    {
        failUI.Show();
        HideInGameUI();

    }

    public void PlayGameButtonPressed()
    {
        mainMenu.Hide();

        gameDirector.RestartLevel();
    }

    public void LoadNextLevelGameButtonPressed()
    {
        winUI.Hide();
        gameDirector.LoadNextLevel();
    }

    public void RetryButtonPressed()
    {
        failUI.Hide();
        gameDirector.RestartLevel();

    }

    public void ShowInGameUI(int levelNo, int coinCount)
    {
        levelUI.Show(levelNo);
        coinUI.UpdateCoinCount(0);
        coinUI.Show(coinCount);
    }

    public void HideInGameUI()
    {
        levelUI.Hide();
        coinUI.Hide();
    }
}

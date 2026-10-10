using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int coinCount;
    public CoinUI coinUI;
    public GameDirector gameDirector;

    [SerializeField] private ControlType controlType;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public void RestartPlayer()
    {

    }

    public void CoinCollected()
    {
         
        coinCount++;  
        coinUI.UpdateCoinCount(coinCount);
        Debug.Log("Coin Collected");
        

    }


    private void Update()
    {
        if (gameDirector.gameState != GameState.GamePlay)
        {
            return;
        }

        if (controlType == ControlType.Keyboard)
        {
            var dir = Vector2.zero;

            if (Keyboard.current.dKey.isPressed)
            {
                dir = Vector2.right;

            }
            rb.linearVelocity = dir * speed;

            if (Keyboard.current.aKey.isPressed)
            {
                dir = Vector2.left;
            }
            rb.linearVelocity = dir * speed;
        }
        else if (controlType == ControlType.Mouse)
        {
            var mouseScreenPos = Mouse.current.position.ReadValue();
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0));

            var xPos = mouseWorldPos.x;

            xPos = Mathf.Clamp(xPos, -2f, 2f);

            transform.position = new Vector3(xPos, -4, 0);

            rb.linearVelocity = Vector3.zero;


        }
    }
    


    public enum ControlType
    {
        Keyboard,
        Mouse,
    }
}
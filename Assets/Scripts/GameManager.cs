using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    [SerializeField] int timeToEnd;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;

        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        Debug.Log("Time: " + timeToEnd + " s");
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }
    void Stopper ()
    {
        timeToEnd--;
        Debug.Log("Time:" + timeToEnd + " s");
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reoad?");
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }
}
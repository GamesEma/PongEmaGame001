using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ballPrefab;
    public Transform spawnPoint;
    public int scoreToWin = 3;

    private int playerScore = 0;
    private int opponentScore = 0;
    private GameObject activeBall;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        if (activeBall != null)
        {
            Destroy(activeBall);
        }

        activeBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void PlayerScored()
    {
        playerScore++;
        CheckWinCondition();
        SpawnBall();
    }

    public void OpponentScored()
    {
        opponentScore++;
        CheckWinCondition();
        SpawnBall();
    }

    private void CheckWinCondition()
    {
        if (playerScore >= scoreToWin || opponentScore >= scoreToWin)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Implement logic for ending the game, displaying a victory screen, etc.
    }
}


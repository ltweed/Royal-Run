using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameOverText;

    [SerializeField] float startTime = 5f;

    private float timeLeft;
    bool gameOver;

    public bool GameOver => gameOver;


    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        DecreaseTime();
    }

    public void IncreaseTime(float increaseAmount)
    {
        timeLeft += increaseAmount;
    }

    private void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }


}

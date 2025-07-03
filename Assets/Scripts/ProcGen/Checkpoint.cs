using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float adjustTime = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = .2f;
    
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    
    const string playerString = "Player";

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            gameManager.IncreaseTime(adjustTime);
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
            
        }
    }
}

using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] private float spawnWidth = 4f;

    [SerializeField] float minObstacleSpawnTime = .2f;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void DecreaseObstacleSpawnTime(float decreaseAmount)
    {
        obstacleSpawnTime -= decreaseAmount;
        if (obstacleSpawnTime < minObstacleSpawnTime)
        {
            obstacleSpawnTime = minObstacleSpawnTime;
        }
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
          
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

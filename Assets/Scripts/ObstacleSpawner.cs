using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnTime = 1f;
    int obstacleSpawned = 0;
    

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (obstacleSpawned < 5)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstacleSpawned++;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

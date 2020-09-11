using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform shipEnemyPrefab;
    public static EnemyManager Instance;
    public int numberOfEnemies;
    public float spawnRadius;

    public List<Enemy> enemies;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        enemies = new List<Enemy>();

        InvokeRepeating("SpawnShipEnemy", 2f, 2f);

        enemies.Add(FindObjectOfType<Enemy>());
    }

    void SpawnShipEnemy()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(shipEnemyPrefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(10, 15), 0), Quaternion.identity);
        }
    }

    public List<Enemy> GetNeighbors(Enemy enemy, float radius)
    {
        List<Enemy> neighborsFound = new List<Enemy>();
        
        foreach (var otherEnemy in enemies)
        {
            if (otherEnemy == enemy)
            {
                continue;
            }

            if(Vector3.Distance(enemy.position, otherEnemy.position) <= radius)
            {
                neighborsFound.Add(otherEnemy);
            }
        }

        return neighborsFound;
    }
}

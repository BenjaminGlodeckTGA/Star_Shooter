using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform shipEnemyPrefab;
    public static EnemyManager Instance;
    public int numberOfEnemies;
    public float spawnRadius;
    public float bounds;

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
        Spawn(shipEnemyPrefab, numberOfEnemies);

        enemies.Add(FindObjectOfType<Enemy>());
    }

    void Spawn(Transform prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0), Quaternion.identity);
        }
    }

    public List<Enemy> GetNeighbors(Enemy enemy, float radius)
    {
        List<Enemy> neighborsFound = new List<Enemy>();
        
        foreach (var otherEnemy in enemies)
        {
            Debug.Log("foreach work");
            if (otherEnemy == enemy)
            {
                Debug.Log("continue");
                continue;
            }

            if(Vector3.Distance(enemy.position, otherEnemy.position) <= radius)
            {
                Debug.Log("conti");
                neighborsFound.Add(otherEnemy);
            }
        }

        return neighborsFound;
    }
}

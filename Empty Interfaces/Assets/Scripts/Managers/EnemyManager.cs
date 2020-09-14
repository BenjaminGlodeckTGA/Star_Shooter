using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform myShipEnemyPrefab;
    public static EnemyManager ourInstance;
    public int myNumberOfEnemies;
    public float mySpawnRadius;

    public List<Enemy> myEnemies;

    private void Awake()
    {
        if(ourInstance == null)
        {
            ourInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        myEnemies = new List<Enemy>();

        InvokeRepeating("SpawnShipEnemy", 2f, 2f);

        myEnemies.Add(FindObjectOfType<Enemy>());
    }

    void SpawnShipEnemy()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(myShipEnemyPrefab, new Vector3(Random.Range(-mySpawnRadius, mySpawnRadius), Random.Range(10, 15), 0), Quaternion.identity);
        }
    }

    public List<Enemy> GetNeighbors(Enemy anEnemy, float someRadius)
    {
        List<Enemy> neighborsFound = new List<Enemy>();
        
        foreach (var otherEnemy in myEnemies)
        {
            if (otherEnemy == anEnemy)
            {
                continue;
            }

            if(Vector3.Distance(anEnemy.myPosition, otherEnemy.myPosition) <= someRadius)
            {
                neighborsFound.Add(otherEnemy);
            }
        }

        return neighborsFound;
    }
}

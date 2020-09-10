using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void Update()
    {
    public float maxAcceleration;
    public float maxVelocity;

    //PlayerTarget Variables
    public Vector3 playerTarget;
    public float playerTargetPriority;

    //Cohesion Variables
    public float cohesionRadius;
    public float cohesionPriority;

    //Alignment Variables
    public float alignmentRadius;
    public float alignmentPriority;

    //Seperation Variables
    public float seperationRadius;
    public float seperationPriority;

    //Avoidance Variables
    public float avoidanceRadius;
    public float avoidancePriority;

    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;

    
    public void Start()
    {
        position = transform.position;
        velocity = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        acceleration = Combine();
        acceleration = Vector3.ClampMagnitude(acceleration, maxAcceleration);
        velocity = velocity + acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        position = position + velocity * Time.deltaTime;
        transform.position = position;
    }

    protected Vector3 TowardsPlayer()
    {
        GameObject Player;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerTarget = Player.transform.position;
        playerTarget -= this.transform.position;
        return playerTarget.normalized;
    }

    Vector3 Combine()
    {
        Vector3 finalVec = cohesionPriority * Cohesion() + playerTargetPriority * TowardsPlayer();
        return finalVec;
    }

    Vector3 Cohesion()
    {
        Vector3 cohesionVector = new Vector3();
        int countEnemies = 0;
        var neighbors = EnemyManager.Instance.GetNeighbors(this, cohesionRadius);
        if (neighbors.Count == 0)
        {
            Debug.Log("n.count 0");
            return cohesionVector;
        }
        foreach (var enemy in neighbors)
        {
            cohesionVector += enemy.position;
            countEnemies++;
        }
        if(countEnemies == 0)
        {
            Debug.Log("count 0");
            return cohesionVector;
        }

        cohesionVector /= countEnemies;
        cohesionVector = cohesionVector - this.position;

        Debug.Log("vec nor");
        return cohesionVector.normalized;
    }
}

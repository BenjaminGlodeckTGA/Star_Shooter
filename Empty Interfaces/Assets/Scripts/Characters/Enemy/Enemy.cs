using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    Rigidbody2D rb;
    public float maxAcceleration;
    public float maxVelocity;

    //PlayerTarget Variables
    public Vector3 playerTarget;
    public float playerTargetPriority;

    //Cohesion Variables
    public float cohesionRadius;
    public float cohesionPriority;

    //Avoidance Variables
    public float avoidanceRadius;
    public float avoidancePriority;

    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;

    
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = transform.position;
        velocity = new Vector3(0, 0, 0);
        hp = maxHP;
        coolDownCopy = timeBetweenShots;
    }

    public void Update()
    {
        acceleration = Combine();
        acceleration = Vector3.ClampMagnitude(acceleration, maxAcceleration);
        velocity = velocity + acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        position = position + velocity * Time.deltaTime;
        transform.position = position;
        ShootReadyCheck();
        CheckIfAlive();
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
        Vector3 finalVec = cohesionPriority * Cohesion() + playerTargetPriority * TowardsPlayer() + avoidancePriority * Avoidance();
        return finalVec;
    }

    Vector3 Cohesion()
    {
        Vector3 cohesionVector = new Vector3();
        int countEnemies = 0;
        var neighbors = EnemyManager.Instance.GetNeighbors(this, cohesionRadius);
        if (neighbors.Count == 0)
        {
            
            return cohesionVector;
        }
        foreach (var enemy in neighbors)
        {
            cohesionVector += enemy.position;
            countEnemies++;
        }
        if(countEnemies == 0)
        {
            
            return cohesionVector;
        }

        cohesionVector /= countEnemies;
        cohesionVector = cohesionVector - this.position;

        
        return cohesionVector.normalized;
    }

    Vector3 Avoidance()
    {
        Vector3 avoidanceVector = new Vector3();
        var bullets = BulletManager.Instance.GetBullets();
        int countBullets = 0;
        if (bullets.Count == 0)
        {
            return avoidanceVector;
        }
        foreach(var bullet in bullets)
        {
            float dist = Vector3.Distance(bullet.transform.position, gameObject.transform.position);
            if (dist < avoidanceRadius)
            {
                avoidanceVector += Dodge(bullet.transform.position);
                countBullets++;
            }
        }
        if (countBullets == 0)
        {
            return avoidanceVector;
        }

        return avoidanceVector.normalized;
    }

    Vector3 Dodge(Vector3 target)
    {
        Vector3 neededVelocity = (position - target).normalized * maxVelocity;
        return  neededVelocity - velocity;
    }
}

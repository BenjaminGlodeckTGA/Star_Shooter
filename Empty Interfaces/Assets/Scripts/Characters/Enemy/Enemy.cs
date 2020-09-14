using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    Rigidbody2D myRB;
    public float myMaxAcceleration;
    public float myMaxVelocity;

    //PlayerTarget Variables
    public Vector3 myPlayerTarget;
    public float myPlayerTargetPriority;
    public float myPlayerTargetRadius;

    //Cohesion Variables
    public float myCohesionRadius;
    public float myCohesionPriority;
    public float myCohesionRadiusMin;
    //Avoidance Variables
    public float myAvoidanceRadius;
    public float myAvoidancePriority;

    public Vector3 myPosition;
    public Vector3 myVelocity;
    public Vector3 myAcceleration;

    
    public override void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myPosition = transform.position;
        myVelocity = new Vector3(0, 0, 0);
        myCurrentHP = myMaxHP;
        myCoolDownCopy = myTimeBetweenShots;
    }

    public void Update()
    {
        ShootReadyCheck();
        CheckIfAlive();
    }

    public void FixedUpdate()
    {
        myAcceleration = Combine();
        myAcceleration = Vector3.ClampMagnitude(myAcceleration, myMaxAcceleration);
        myVelocity = myVelocity + myAcceleration * Time.deltaTime;
        myVelocity = Vector3.ClampMagnitude(myVelocity, myMaxVelocity);
        myPosition = myPosition + myVelocity * Time.deltaTime;
        transform.position = myPosition;
    }

    protected Vector3 TowardsPlayer()
    {
        GameObject Player;
        Player = GameObject.FindGameObjectWithTag("Player");
        myPlayerTarget = Player.transform.position;

        myPlayerTarget -= this.transform.position;
        return myPlayerTarget.normalized;
    }

    Vector3 Combine()
    {
        Vector3 finalVec = myCohesionPriority * Cohesion() + myPlayerTargetPriority * TowardsPlayer() + myAvoidancePriority * Avoidance();
        return finalVec;
    }

    Vector3 Cohesion()
    {
        Vector3 cohesionVector = new Vector3();
        int countEnemies = 0;
        var neighbors = EnemyManager.ourInstance.GetNeighbors(this, myCohesionRadius);
        if (neighbors.Count == 0)
        {
            
            return cohesionVector;
        }
        foreach (var enemy in neighbors)
        {
            float dist = Vector3.Distance(enemy.myPosition, gameObject.transform.position);
            if (dist > myCohesionRadiusMin)
            {
                cohesionVector += enemy.myPosition;
                countEnemies++;
            }
            if (dist < myCohesionRadiusMin)
            {
                cohesionVector -= enemy.myPosition;
                countEnemies++;
            }
        }
        if(countEnemies == 0)
        {
            
            return cohesionVector;
        }

        cohesionVector /= countEnemies;
        cohesionVector = cohesionVector - this.myPosition;

        
        return cohesionVector.normalized;
    }

    Vector3 Avoidance()
    {
        Vector3 avoidanceVector = new Vector3();
        var bullets = BulletManager.ourInstance.GetBullets();
        int countBullets = 0;
        if (bullets.Count == 0)
        {
            return avoidanceVector;
        }
        foreach(var bullet in bullets)
        {
            float dist = Vector3.Distance(bullet.transform.position, gameObject.transform.position);
            if (dist < myAvoidanceRadius && bullet.name.Contains("PlayerBullet"))
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

    Vector3 Dodge(Vector3 aTarget)
    {
        Vector3 neededVelocity = (myPosition - aTarget).normalized * myMaxVelocity;
        return  neededVelocity - myVelocity*2;
    }
}

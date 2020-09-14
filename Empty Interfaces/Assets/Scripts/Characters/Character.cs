using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float myTimeBetweenShots;
    public int myMaxHP;
    protected int myCurrentHP;
    protected float myLowestCoolDown;
    protected float myHighestCoolDown;
    protected float myCoolDownCopy;
    protected bool isShooting = true;
    public float myRandomModifier;
    protected static int ourKills;

    // Start is called before the first frame update
    public virtual void Start()
    {
        ourKills = 0;
        myCurrentHP = myMaxHP;
        myCoolDownCopy = myTimeBetweenShots;
        Debug.Log("START VALUE OF COPY = " + myCoolDownCopy);
    }

    protected void CheckIfAlive()
    {
        // if character is dead
        if (myCurrentHP <= 0)
        {
            // destroys the character
            Destroy(gameObject);
            ourKills++;
        }
    }

    public int GetKills()
    {
        return ourKills;
    }

    public int GetHP()
    {
        return myCurrentHP;
    }

    protected virtual void ShootReadyCheck()
    {
        myTimeBetweenShots -= Time.deltaTime; // timer is decreased

        // generates a random cooldown timer based on the random modifier
        myLowestCoolDown = myCoolDownCopy - (myRandomModifier * myCoolDownCopy);
        myHighestCoolDown = myCoolDownCopy + (myRandomModifier * myCoolDownCopy);

        // timer cant go below 0
        if (myTimeBetweenShots <= 0)
        {
            myTimeBetweenShots = 0;
        }

        // if timer is 0
        if (myTimeBetweenShots <= 0)
        {
            myTimeBetweenShots = Random.Range(myLowestCoolDown, myHighestCoolDown);
            // character shoots
            Shoot();
        }
    }

    protected void Shoot()
    {
        isReadyToShoot = true;
    }

    public void Hurt(int someDamage)
    {
        myCurrentHP -= someDamage;
        Debug.Log("HP: " + myCurrentHP);
    }
}

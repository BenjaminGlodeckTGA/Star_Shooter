using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float timeBetweenShots;
    public float coolDownRandomRangeValue;
    protected float coolDownCopy;
    protected float lowestCoolDown;
    protected float highestCooldown;
    protected bool isShooting = true;

    // Start is called before the first frame update
    protected void Start()
    {
        coolDownCopy = timeBetweenShots;
        Debug.Log("START VALUE OF COPY = " + coolDownCopy);
    }

    protected virtual void ShootReadyCheck()
    {
        lowestCoolDown = coolDownCopy - (coolDownRandomRangeValue * coolDownCopy);
        highestCooldown = coolDownCopy + (coolDownRandomRangeValue * coolDownCopy);

        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = Random.Range(lowestCoolDown, highestCooldown);
            Debug.Log(timeBetweenShots);
            //Debug.Log("Enemy cooldown: " + coolDownCopy);
            Shoot();
        }
    }

    protected void Shoot()
    {
        isReadyToShoot = true;
    }
}

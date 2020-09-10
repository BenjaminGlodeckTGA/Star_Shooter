using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float timeBetweenShots;
    protected float lowCoolDown;
    protected float highCoolDown;
    protected float coolDownCopy;
    protected bool isShooting = true;
    public float randomModifier;

    // Start is called before the first frame update
    protected void Start()
    {
        coolDownCopy = timeBetweenShots;
        Debug.Log("START VALUE OF COPY = " + coolDownCopy);
    }

    protected virtual void ShootReadyCheck()
    {
        timeBetweenShots -= Time.deltaTime;

        lowCoolDown = coolDownCopy - (randomModifier * coolDownCopy);
        highCoolDown = coolDownCopy + (randomModifier * coolDownCopy);

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }

        if (timeBetweenShots <= 0 && isShooting)
        {
            timeBetweenShots = Random.Range(lowCoolDown, highCoolDown);
            Debug.Log("Enemy: " + timeBetweenShots);
            //Debug.Log("Enemy cooldown: " + coolDownCopy);
            Shoot();
        }
    }

    protected void Shoot()
    {
        isReadyToShoot = true;
    }
}

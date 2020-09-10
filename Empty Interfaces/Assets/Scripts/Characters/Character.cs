using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float timeBetweenShots;
    public int maxHP;
    public int hp;
    protected float lowCoolDown;
    protected float highCoolDown;
    protected float coolDownCopy;
    protected bool isShooting = true;
    public float randomModifier;

    // Start is called before the first frame update
    protected void Start()
    {
        hp = maxHP;
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
            //.Log("Enemy: " + timeBetweenShots);
            //Debug.Log("Enemy cooldown: " + coolDownCopy);
            Shoot();
        }
    }

    protected void Shoot()
    {
        isReadyToShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            hp--;
            Debug.Log("CHARACTER HP: " + hp);
        }
    }

}

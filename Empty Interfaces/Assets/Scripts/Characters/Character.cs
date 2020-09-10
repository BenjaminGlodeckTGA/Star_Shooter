using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float timeBetweenShots;
    public float randomModifier;
    protected int hp;
    public int maxHp;
    protected float lowCoolDown;
    protected float highCoolDown;
    protected float coolDownCopy;
    protected bool isShooting = true;

    // Start is called before the first frame update
    protected void Start()
    {
        hp = maxHp;
        coolDownCopy = timeBetweenShots;
        //Debug.Log("START VALUE OF COPY = " + coolDownCopy);
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
            //Debug.Log("Enemy: " + timeBetweenShots);
            //Debug.Log("Enemy cooldown: " + coolDownCopy);
            Shoot();
        }
    }

    protected void Shoot()
    {
        isReadyToShoot = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISION!");
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            hp--;
            Debug.Log("CHARACTER HP: " + hp);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool isReadyToShoot = false;
    public float timeBetweenShots;
    public int maxHP;
    protected int hp;
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

    public void Hurt(int damage)
    {
<<<<<<< Updated upstream
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            hp--;
            Debug.Log("CHARACTER HP: " + hp);
        }
=======
        hp -= damage;
        Debug.Log("HP: " + hp);
>>>>>>> Stashed changes
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (gameObject.tag.Contains("Enemy"))
    //    {
    //        Debug.Log("ENEMY FOUND");
    //        // if character collides with a projectile
    //        if (other.gameObject.CompareTag("Projectile"))
    //        {
    //            Debug.Log("ENEMY HIT");
    //            // destroys projectile
    //            Destroy(other.gameObject);
    //            // damages character
    //            hp--;
    //        }
    //    }
    //    if (gameObject.CompareTag("Player"))
    //    {
    //        // if character collides with a projectile
    //        if (other.gameObject.tag.Contains("Enemy"))
    //        {
    //            // destroys projectile
    //            Destroy(other.gameObject);
    //            // damages character
    //            hp--;

    //            Debug.Log("PLAYER HIT");
    //        }
    //    }
        
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float myBulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRB.AddForce(transform.up * myBulletSpeed);
    }

    private void OnBecameInvisible()
    {
        BulletManager.ourInstance.DestroyBullet(gameObject);
    }

    void OnTriggerEnter2D(Collider2D anOther)
    {
        if (anOther.isTrigger)
        {
            return;
        }
        else
        {
            if (anOther.gameObject.name.Contains("Enemy"))
            {
                Debug.Log("ENEMY FOUND");
                // if character collides with a projectile
                if (gameObject.name.Contains("PlayerBullet"))
                {
                    Debug.Log("ENEMY HIT");
                    // destroys projectile
                    BulletManager.ourInstance.DestroyBullet(gameObject);
                    // damages character
                    anOther.gameObject.GetComponent<Enemy>().Hurt(1);
                }
            }
            if (anOther.gameObject.name.Contains("Player"))
            {
                // if character collides with a projectile
                if (gameObject.name.Contains("Enemy"))
                {
                    // destroys projectile
                    BulletManager.ourInstance.DestroyBullet(gameObject);
                    // damages character
                    anOther.gameObject.GetComponent<Player>().Hurt(1);
                    Debug.Log("PLAYER HIT");
                }
            }
        }  
    }
}

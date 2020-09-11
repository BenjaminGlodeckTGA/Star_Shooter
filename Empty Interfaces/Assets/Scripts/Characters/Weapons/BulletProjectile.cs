using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour, IShootable
{
    public Rigidbody2D rb;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed);
    }

    private void OnBecameInvisible()
    {
        BulletManager.Instance.DestroyBullet(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            return;
        }
        else
        {
            if (other.gameObject.name.Contains("Enemy"))
            {
                Debug.Log("ENEMY FOUND");
                // if character collides with a projectile
                if (gameObject.name.Contains("PlayerBullet"))
                {
                    Debug.Log("ENEMY HIT");
                    // destroys projectile
                    Destroy(gameObject);
                    // damages character
                    other.gameObject.GetComponent<Enemy>().Hurt(1);
                }
            }
            if (other.gameObject.name.Contains("Player"))
            {
                // if character collides with a projectile
                if (gameObject.name.Contains("Enemy"))
                {
                    // destroys projectile
                    Destroy(gameObject);
                    // damages character
                    other.gameObject.GetComponent<Player>().Hurt(1);
                    Debug.Log("PLAYER HIT");
                }
            }
        }  
    }
}

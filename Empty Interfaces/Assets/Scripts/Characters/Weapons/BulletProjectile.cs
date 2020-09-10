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

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        //Debug.Log("Bullet destroyed");
>>>>>>> Stashed changes
    }
}

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
}

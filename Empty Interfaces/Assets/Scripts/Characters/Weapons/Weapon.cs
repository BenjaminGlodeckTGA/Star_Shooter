using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    GameObject wielder;
    public Transform projectileSpawnPoint;

    private void Start()
    {
        var parentPosition = transform.parent;
        wielder = parentPosition.gameObject;
    }

    private void Update()
    {
        // if wielder wants to shoot and is able to
        if (wielder.GetComponent<Character>().isReadyToShoot)
        {
            // weapon fires
            Fire();
            // wielder is no longer able to shoot
            wielder.GetComponent<Character>().isReadyToShoot = false;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        
        BulletManager.Instance.AddBullets(bullet);
    }
}

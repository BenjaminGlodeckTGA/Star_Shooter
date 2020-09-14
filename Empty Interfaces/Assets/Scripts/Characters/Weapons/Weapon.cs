using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject myProjectile;
    GameObject myWielder;
    public Transform myProjectileSpawnPoint;

    private void Start()
    {
        var parentPosition = transform.parent;
        myWielder = parentPosition.gameObject;
    }

    private void Update()
    {
        // if wielder wants to shoot and is able to
        if (myWielder.GetComponent<Character>().isReadyToShoot)
        {
            // weapon fires
            Fire();
            // wielder is no longer able to shoot
            myWielder.GetComponent<Character>().isReadyToShoot = false;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(myProjectile, myProjectileSpawnPoint.position, myProjectileSpawnPoint.rotation);
        
        BulletManager.ourInstance.AddBullets(bullet);
    }
}

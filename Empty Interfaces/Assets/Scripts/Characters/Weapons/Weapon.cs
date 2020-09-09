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
        if (wielder.GetComponent<Character>().isReadyToShoot)
        {
            Fire();
            wielder.GetComponent<Character>().isReadyToShoot = false;
        }
    }

    void Fire()
    {
        Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }
}

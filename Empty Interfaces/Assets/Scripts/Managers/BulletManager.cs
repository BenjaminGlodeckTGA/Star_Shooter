using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<GameObject> bullets;
    public static BulletManager Instance;
    public GameObject bulletPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        List<GameObject> bullets = new List<GameObject>();
    }
    public void AddBullets(GameObject bullet)
    {
        bullets.Add(bullet);
    }

    public void DestroyBullet(GameObject bullet)
    {
        foreach(var otherBullet in bullets.ToList())
        {
            if (otherBullet == bullet)
            {
                bullets.Remove(bullet);
            }
        }
        Destroy(bullet);
    }
   
    public List<GameObject> GetBullets ()
    {
        return bullets;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<GameObject> myBullets;
    public static BulletManager ourInstance;
    public GameObject myBulletPrefab;

    private void Awake()
    {
        if (ourInstance == null)
        {
            ourInstance = this;
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
        myBullets.Add(bullet);
    }

    public void DestroyBullet(GameObject aBullet)
    {
        foreach(var otherBullet in myBullets.ToList())
        {
            if (otherBullet == aBullet)
            {
                myBullets.Remove(aBullet);
            }
        }
        Destroy(aBullet);
    }
   
    public List<GameObject> GetBullets ()
    {
        return myBullets;
    }

}

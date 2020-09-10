using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float space;

    // Update is called once per frame
    void Update()
    {
        space = Input.GetAxisRaw("Jump");
        ShootReadyCheck();
    }

    protected override void ShootReadyCheck()
    {
        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }

        if (timeBetweenShots <= 0 && space != 0)
        {
            timeBetweenShots = coolDownCopy;
            Debug.Log("Player cooldown: " + timeBetweenShots);
            Shoot();
        }
    }
<<<<<<< Updated upstream
=======

    public void Move()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
>>>>>>> Stashed changes
}

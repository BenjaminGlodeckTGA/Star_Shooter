using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float mySpace;
    public float mySpeed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        mySpace = Input.GetAxisRaw("Jump");
        // checks if player can shoot
        ShootReadyCheck();
        // moves player
		Move();
    }

    protected override void ShootReadyCheck()
    {
        myTimeBetweenShots -= Time.deltaTime; // decrease timer

        // timer cant go below 0
        if (myTimeBetweenShots <= 0)
        {
            myTimeBetweenShots = 0;
        }

        // if timer runs out and space is pressed
        if (myTimeBetweenShots <= 0 && mySpace != 0)
        {
            // reset timer
            myTimeBetweenShots = myCoolDownCopy;
            // and shoot
            Shoot();
        }
    }
    public void Move()
    {
        //Makes Character move with key arrows
        transform.Translate(mySpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
}

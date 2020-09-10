using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float space;
    public float speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        space = Input.GetAxisRaw("Jump");
        // checks if player can shoot
        ShootReadyCheck();
        // moves player
		Move();
    }

    protected override void ShootReadyCheck()
    {
        timeBetweenShots -= Time.deltaTime; // decrease timer

        // timer cant go below 0
        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }

        // if timer runs out and space is pressed
        if (timeBetweenShots <= 0 && space != 0)
        {
            // reset timer
            timeBetweenShots = coolDownCopy;
            // and shoot
            Shoot();
        }
    }
    public void Move()
    {
        //Makes Character move with key arrows
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float speed = 4.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
}

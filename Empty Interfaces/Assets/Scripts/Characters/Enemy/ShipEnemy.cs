using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.UI;
using UnityEngine;

public class ShipEnemy : Enemy
{
    // Update is called once per frame
    void Update()
    {
        ShootReadyCheck();
        CheckIfAlive();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;


    public void Update()
    {
        ScreenBoundary();

    }
    public void ScreenBoundary()
    {
        Player.transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, -Screen.width/100, Screen.width/100), Player.transform.position.y, Player.transform.position.z);
    }
}


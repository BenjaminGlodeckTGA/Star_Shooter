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
        Player.transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, -9.5f, 9.5f), Player.transform.position.y, Player.transform.position.z);
    }
}


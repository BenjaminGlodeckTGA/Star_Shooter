﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;


    public void Update()
    {
        ScreenBoundary();

        //  if player is dead
        if (player.GetComponent<Player>().hp <= 0)
        {
            // load game over scene
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            Destroy(player);
        }

    }
    public void ScreenBoundary()
    {
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -Screen.width/100, Screen.width/100), player.transform.position.y, player.transform.position.z);
    }
}


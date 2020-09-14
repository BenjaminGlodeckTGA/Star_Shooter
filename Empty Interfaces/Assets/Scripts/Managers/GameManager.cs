using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int killsToWin;

    public void Update()
    {
        ScreenBoundary();

        //  if player is dead
        if (player.GetComponent<Player>().GetHP() <= 0)
        {
            // load game over scene
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            Destroy(player);
        }

        if (player.GetComponent<Player>().GetKills() >= killsToWin)
        {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            player.GetComponent<Player>().Hurt(1);
            Destroy(collision.gameObject);
        }
    }
    public void ScreenBoundary()
    {
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -Screen.width/100, Screen.width/100), player.transform.position.y, player.transform.position.z);
    }
}


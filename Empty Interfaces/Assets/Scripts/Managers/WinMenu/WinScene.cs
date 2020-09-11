using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxisRaw("Jump");

        // if space is pressed
        if (space != 0)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}

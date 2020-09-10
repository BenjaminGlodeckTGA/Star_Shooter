using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        //Loads scene that is chosen in inspector
        SceneManager.LoadScene(sceneName);
    }
}

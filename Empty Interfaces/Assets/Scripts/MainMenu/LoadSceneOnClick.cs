using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene(string someSceneName)
    {
        //Loads scene that is chosen in inspector
        SceneManager.LoadScene(someSceneName);
    }
}

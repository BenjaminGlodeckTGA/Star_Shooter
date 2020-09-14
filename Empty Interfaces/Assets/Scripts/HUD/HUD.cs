using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image myHealthBar;
    public Character myCharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.fillAmount = (float)myCharacter.GetHP() / (float)myCharacter.myMaxHP;
    }
}

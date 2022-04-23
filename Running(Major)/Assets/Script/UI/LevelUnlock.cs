using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButton;
    public  int unlockedLevel;
    void Start()
    {
       unlockedLevel  = PlayerPrefs.GetInt("levelToUnlock",3);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 3 > unlockedLevel )
            {
                levelButton[i].interactable = false;
            }
            else
            {
                levelButton[i].transform.Find("ChainImg").GetComponent<Image>().enabled = false;
            }
        }

    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    int currentCoin;
    [SerializeField] SaveData save;
    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        save = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<SaveData>();
        save.RetriveData();
        currentCoin = save.coins;
       // Debug.Log(currentCoin);
    }
    public void AddScore(int score)
    {
        currentCoin += score;
        PlayerPrefs.SetInt("Coin", currentCoin );
        save.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Renderer playerRenderer;
    public Transform  player;
    public ShopItems[] skins;
  //  public TailPartical [] tails;

    public GameObject equipButton;
    public GameObject buyButton;
    int currentIndex;
    int currentTail;
    void Start()
    {
        foreach (ShopItems  s in  skins )
        {
            if( s.price==0 )
            {
                s.isUnlock = true;
            }
            else if(PlayerPrefs.GetInt(s.name,0)==1)
            {
                s.isUnlock = true;
            }
           
        }
       // playerRenderer.material = skins[0].skinMaterials;
      //  tails[0].partical.transform.parent = player.transform;
    }
    private void Update()
    {
        DataUpdate();
    }
    void DataUpdate()
    {
        foreach (ShopItems s in skins)
        {
            if (s.price == 0)
            {
                s.isUnlock = true;
            }
            else if (PlayerPrefs.GetInt(s.name, 0) == 1)
            {
                s.isUnlock = true;
            }

        }
    }
        public void ChangeSkin(int value)
    {
        currentIndex += value;
        if(currentIndex<0)
        {
            currentIndex = skins.Length - 1;
        }  if(currentIndex>=skins.Length )
        {
            currentIndex = 0;
        }
      //  playerRenderer.material = skins[currentIndex].skinMaterials;
    }  
    public void ChangePartical(int value)
    {
        currentTail += value;
        if(currentTail<0)
        {
            currentTail = skins.Length - 1;
        }  if(currentTail>=skins.Length )
        {
            currentTail = 0;
        }
      //  tails[currentTail].partical.transform.parent = player.transform;
    }
    public void BuyItems()
    {
        ShopItems skin = skins[currentIndex];
        PlayerPrefs.SetInt(skin.name, 1);
    }
}

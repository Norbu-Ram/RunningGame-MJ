using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinsDisplay : MonoBehaviour
{
    [SerializeField] GameObject sport;

    [SerializeField] List<PlayerSkins> skins;

    private void Start()
    {
        DisplaySkin (0);
    }
    public void ChangeSkins(int index )
    {
            DisplaySkin(index );
    }
    public void DisplaySkin(int index)
    {
        
        if (sport.transform.childCount > 0)
        {
            Destroy(sport.transform.GetChild(0).gameObject);
        }
        
            GameObject obj =Instantiate(skins[index].playerSkins, sport.transform.position, Quaternion.identity);
            obj.transform.parent = sport.transform;

    }
}

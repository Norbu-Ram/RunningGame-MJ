using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header ("Coins")]
    [SerializeField] Text coinTxt;
    [SerializeField] int currentCoin;
    [SerializeField] int remainCoin;

    int selectedSkin = 0;

    public GameObject bullateHole;
    public GameObject leftButton;
    public GameObject rightButton;
    
    AudioSource audioSource;
    public AudioClip changeClip;
    public AudioClip buyClip;

    [Header("Player")]
    // that is applied to the cube 
    [SerializeField] List<Material> skinsMaterials;
    // apply materials on it 

    [SerializeField] Renderer playerRenderer;

    [Header("Save")]
    [SerializeField] SaveData saveData;

    [Header("Class")]
    [SerializeField] Skins[] skins;

    [Header("Buttons")]
    [SerializeField] Button buyButton;
    [SerializeField] Button equipButton;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

       
        audioSource = GetComponent<AudioSource>();
        if (saveData != null)
        {
            saveData.RetriveData() ;
            currentCoin = saveData.coins;
            coinTxt.text = " : "+currentCoin.ToString();
        }

        foreach (Skins s in skins)
        {
            if (s.price == 0)
            {
                s.isUnlocked = true;
                EquipAndBuy(true);
            }
            else
            {
                s.isUnlocked = PlayerPrefs.GetInt(s.name, 0) == 0 ? false : true;
            }
        }

        //Just to show which skin is selected 
        int i = PlayerPrefs.GetInt("SelectedSkin", 0);
        playerRenderer.material = skinsMaterials[i];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextSkin();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousSkin();
        }   if (Input.GetKeyDown(KeyCode.C ))
        {
            //saveData.Save();
            //remainCoin = saveData.coins;
        }
        UIUpdate();
    }
    void EquipAndBuy(bool isActive)
    {
        equipButton.gameObject.SetActive(isActive);
        buyButton.gameObject.SetActive(!isActive);
    }

    void UIUpdate()
    {

        Skins s = skins[selectedSkin];
        buyButton.GetComponentInChildren<Text>().text  = "Buy $ " + s.price.ToString(); 

        if (s.isUnlocked == true )
        {
            // active equip button and disable buy
            EquipAndBuy(true  );
        }
        else
        {
            // Buy button enable and Equip is disable 
            EquipAndBuy(false);

            // need to check coin
            if (s.price <= currentCoin  )
            {
                buyButton.interactable = true;
                buyButton.GetComponentInChildren<Text>().color = Color.black;
            }
            else
            {
                buyButton.interactable = false;
                buyButton.GetComponentInChildren<Text>().color = Color.gray ;
            }
        }
    }
    //buy button 
    public void Buy()
    {
        Skins s = skins[selectedSkin];
    
    }
    public void UnlockSkins()
    {
        audioSource.PlayOneShot(buyClip);
        Skins s = skins[selectedSkin];
        PlayerPrefs.SetInt(s.name, 1);
       // PlayerPrefs.SetInt("UnlockedCar", selectedSkin );
         s.isUnlocked = true    ;

        remainCoin = currentCoin - s.price;
        coinTxt.text = ":" + remainCoin.ToString();
        PlayerPrefs.SetInt("Coin", remainCoin);

    }
    public void NextSkin()
    {
       
        audioSource.PlayOneShot(changeClip );

        selectedSkin++;
        if (selectedSkin >= skinsMaterials.Count)
        {
            selectedSkin = 0;
        }
        playerRenderer.material = skinsMaterials[selectedSkin];
        BullateHole(rightButton);
    }
    public void PreviousSkin()
    {
        BullateHole(leftButton);
        audioSource.PlayOneShot(changeClip );

        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin = skinsMaterials.Count - 1;
        }
        playerRenderer.material = skinsMaterials[selectedSkin];
    }
    public void EquipSkin()
    {
        PlayerPrefs.SetInt("SelectedSkin", selectedSkin);
        saveData.Save();
    }

    void BullateHole( GameObject positionToSpawnHole)
    {
        Vector3 randomPos = new Vector2(Random.Range(-4, 4), Random.Range(-4,4));
        Transform position = positionToSpawnHole.transform  ;
        GameObject hole = Instantiate(bullateHole, position.position + randomPos, Quaternion.identity);
        hole.transform.parent = positionToSpawnHole .transform;
    }
}

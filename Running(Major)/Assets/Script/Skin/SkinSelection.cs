
using System.Collections.Generic;
using UnityEngine;



public class SkinSelection : MonoBehaviour
{
    // that is applied to the cube 
    [SerializeField] List<Material> skinsMaterials;
    // apply materials on it 
    [SerializeField] Renderer playerRenderer;

    AudioManager audioManager;
    int selectedSkin = 0;

    [SerializeField] SaveData saveData;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
        }
    }
    public void NextSkin()
    {
        audioManager.playSound("MapChange");
        selectedSkin++;
        if (selectedSkin >= skinsMaterials.Count)
        {
            selectedSkin = 0;
        }
        playerRenderer.material = skinsMaterials[selectedSkin];
    }

    public void PreviousSkin()
    {
        audioManager.playSound("MapChange");
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
}

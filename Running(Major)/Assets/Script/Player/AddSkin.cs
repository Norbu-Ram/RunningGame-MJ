using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AddSkin : MonoBehaviour
{
    [SerializeField] List<Material> skinsMaterials;
    [SerializeField] Renderer playerRenderer;
    int selectedSkin = 0;

    [SerializeField ]
    SaveData savedata;
    void Start()
    {
        savedata.RetriveData();
        playerRenderer.material = skinsMaterials[savedata.selection];
    }
}

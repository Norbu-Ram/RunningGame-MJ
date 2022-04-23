using UnityEngine;
[System.Serializable]
public class ShopItems
{
    public string name;
    public int price;
    public bool isUnlock;
    public int currentSkin;
    public string descriptation;
    public Renderer renderer;
    public Material[]   skinMaterials;

    public void DataUpdate()
    {

        renderer.material = skinMaterials[currentSkin ];
    }
        

}
//[System.Serializable ]
//public class TailPartical 
//{
//    public string name;
//    public int price;
//    public bool isUnlock;
//    public string descriptation;
//    public GameObject partical;

//}

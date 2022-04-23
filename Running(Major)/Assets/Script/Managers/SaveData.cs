using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{

    public int selection;
    public int coins;

    [System.Serializable]
    public class Data
    {
        public int selectedSkin;
        public int saveCoin;
    }

    public void Save()
    {
        Data myData = new Data();
        // value is set When equip butten is clicked 
        myData.selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        myData.saveCoin = PlayerPrefs.GetInt("Coin", 0);
        string json = JsonUtility.ToJson(myData);
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);
    }
    public void RetriveData()
    {
        string path = Application.dataPath + "/SaveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data myData = JsonUtility.FromJson<Data>(json);
            selection = myData.selectedSkin;
            coins = myData.saveCoin;
        }
    }
}

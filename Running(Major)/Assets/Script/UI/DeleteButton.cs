
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeleteButton : MonoBehaviour
{
    public Image levelSelectImage;
    public GameObject deletePanel;
    public SaveData saveData;

    private void Start()
    {
        saveData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveData>();
    }
    public void DeletePlayerPrafs()
    {
        levelSelectImage.enabled = false;
        deletePanel.SetActive(true);
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        // the coin is stored on JSON File so When we delete all progess is need to  set 0 
        PlayerPrefs.SetInt("Coin", 0);
        saveData.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DeleteCancel()
    {
        levelSelectImage.enabled = true;
        deletePanel.SetActive(false );
    }

}

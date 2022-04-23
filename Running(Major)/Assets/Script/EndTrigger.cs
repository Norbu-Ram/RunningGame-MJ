using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour
{
    // if it  is last level then unlock new map
    [SerializeField] bool isLastLevel;
    [SerializeField] GameManager gameManager;
    [SerializeField] Score score;

    //[SerializeField] string levelToLoad;
    [SerializeField] int currentLevel;

    private void Start()
    {
        Time.timeScale = 1;
        currentLevel  = SceneManager.GetActiveScene().buildIndex;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<Score>();
    }

    public GameObject levelCompletPanel;
    public GameObject lastLevelPanel;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("levelToUnlock",3) == currentLevel)
            {
                 PlayerPrefs.SetInt("levelToUnlock", currentLevel + 1);
            }
            if (levelCompletPanel != null && !isLastLevel)
            {
                score.AddScore(5);
                levelCompletPanel.SetActive(true);
            }

            if (isLastLevel)
            {
                score.AddScore(10);
                //   gameManager.UnlockLevel ();
                lastLevelPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
}

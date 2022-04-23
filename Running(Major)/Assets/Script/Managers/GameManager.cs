using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] bool isOver = false;

    [SerializeField] GameObject pausePanel;
    public bool isPause = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel != null)
        {
            Pause();
        }
    }
    public void EndGame()
    {
        isOver = true;
        if (isOver)
        {
            Invoke("Restart", delayTime);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Debug.Log("Quit ");
        Application.Quit();
    }
    void Pause()
    {
        if (!isOver && !isPause)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }

    }


}

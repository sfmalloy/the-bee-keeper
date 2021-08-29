using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject unpausedUI;
    public float time;
    
    public Text timeText;
    public Text gameOverScore;

    bool gameOver;

    void Start()
    {
        isPaused = false;
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            pausedUI.SetActive(false);
            unpausedUI.SetActive(false);
            gameOverUI.SetActive(true);
            Time.timeScale = 0;

            gameOverScore.text = "" + player.GetComponent<BeeCount>().caughtBeeCount;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            isPaused = !isPaused;

            pausedUI.SetActive(isPaused);
            unpausedUI.SetActive(!isPaused);
        }
        else
        {
            time -= Time.deltaTime;
            timeText.text = "" + Mathf.RoundToInt(time);
        }

        if (time <= 0)
        {
            gameOver = true;
        }
    }

    public void RestartGame()
    {
        isPaused = false;
        gameOver = false;
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        unpausedUI.SetActive(true);
        Time.timeScale = 1;

        SceneLoader.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

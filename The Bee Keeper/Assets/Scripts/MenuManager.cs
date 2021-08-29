using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controls;

    public void PlayGame()
    {
        SceneLoader.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowControls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void ShowMenu()
    {
        controls.SetActive(false);
        mainMenu.SetActive(true);
    }
}

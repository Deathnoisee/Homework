using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void mainMenu () 
    {
        SceneManager.LoadScene("Main menu");
        Time.timeScale = 1.0f;
    }
    public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1.0f;
    }

}
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
        DataPersistenceManager.instance.SaveGame();
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
        DataPersistenceManager.instance.SaveGame();
        Time.timeScale = 1.0f;
    }

}
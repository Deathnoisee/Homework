using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void StartThegame()
    {
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("level 1");
    }
    
    public void MainMenu ()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void ContinueGame()
    {
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene("level 1");
    }



}

using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void Startgame()
    {
        SceneManager.LoadScene("level 1");
    }
    
    public void MainMenu ()
    {
        SceneManager.LoadScene("Main menu");
    }
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

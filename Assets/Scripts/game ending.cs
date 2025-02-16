using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneName = "MainMenu"; // Change this to your scene name

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            Debug.Log("Collision detected! Loading scene: main menu" );
            SceneManager.LoadScene("Main menu"); // Load Main Menu scene
        }
    }
}

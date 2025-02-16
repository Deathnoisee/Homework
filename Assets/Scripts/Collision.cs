using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject mapObject; // Assign the object you want to change in the map

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            Debug.Log("Player collided! Changing the map...");
            mapObject.SetActive(!mapObject.activeSelf); // Toggle visibility
            gameObject.SetActive(false);
        }
    }
}

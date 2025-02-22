using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.VFX;

public class CollisionTrigger : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    } 
    public GameObject mapObject; // Assign the object you want to change in the map
    private bool collected = false;
    public void LoadData(GameData data)
    {
        data.openedPaths.TryGetValue(id, out collected);
        if (collected)
        {
            gameObject.SetActive(false);
        }
        bool mapObjectState;
        if (data.mapObjects.TryGetValue(id, out mapObjectState))
        {
            mapObject.SetActive(mapObjectState);
        }
    }
    public void SaveData(ref GameData data)
    {
        if (data.openedPaths.ContainsKey(id))
        {
            data.openedPaths.Remove(id);
        }
        data.openedPaths.Add(id, collected);
        if (data.mapObjects.ContainsKey(id))
        {
            data.mapObjects.Remove(id);
        }
        data.mapObjects.Add(id, mapObject.activeSelf);
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            
            collected = true;
            Debug.Log("Player collided! Changing the map...");
            mapObject.SetActive(!mapObject.activeSelf); // Toggle visibility
            gameObject.SetActive(false);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> openedPaths;
    public SerializableDictionary<string, bool> mapObjects;
    public GameData()
    {
        playerPosition = new Vector3(-6.5f, -4.464f, 0);
        openedPaths = new SerializableDictionary<string, bool>();
        mapObjects = new SerializableDictionary<string, bool>();
    }
}

using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
   [Header("File Storage Config")]
   [SerializeField] private string fileName;
   
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    
    private FileDateHandler dataHandler;

    public static DataPersistenceManager instance { get; private set;}
    private void Awake()
    {      
        if (instance != null)
        {
            Debug.Log("Instance of DataPersistenceManager already exists, destroying this one.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDateHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        
        if (this.gameData == null)
        {
            NewGame();
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        dataHandler.save(gameData);
    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }


}

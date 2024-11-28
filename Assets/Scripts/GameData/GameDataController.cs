using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour
{
    public GameObject player;
    [HideInInspector] public string savedFile;
    [HideInInspector] public string savedFilelevel;
    public GameData gameData = new GameData();
    public LevelData levelData = new LevelData();
    void Awake(){
        savedFile = Application.dataPath + "/gameData.json";
        savedFilelevel = Application.dataPath + "/levelData.json";
        player = GameObject.FindGameObjectWithTag("Player");
        LoadData();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            LoadData();
        }
        if(Input.GetKeyDown(KeyCode.G)){
            SaveData();
        }
    }
    public void LoadData(){
        if(File.Exists(savedFile)){
            string content = File.ReadAllText(savedFile);
            gameData = JsonUtility.FromJson<GameData>(content);
            if (player != null)
            {
                Debug.Log("Player position: " + gameData.position);
                player.transform.position = gameData.position;
                player.GetComponent<LifeManager>().playerLife = gameData.health;
            }
        }else{
            Debug.Log("The File does not exist");
        }
    }

    public int LoadHealth()
    {
        if (File.Exists(savedFile))
        {
            string content = File.ReadAllText(savedFile);
            gameData = JsonUtility.FromJson<GameData>(content);
            return gameData.health;
        }
        else
        {
            Debug.Log("The File does not exist");
            return 3;
        }
    }

    public int LoadLevel()
    {
        if (File.Exists(savedFile))
        {
            string content = File.ReadAllText(savedFilelevel);
            levelData = JsonUtility.FromJson<LevelData>(content);
            return levelData.levelint;
        }
        else
        {
            Debug.Log("The File does not exist");
            return 0;
        }
    }

    public void SaveLevel(int num)
    {
        LevelData newData = new LevelData()
        {
            levelint = num
        };
        string jsonString = JsonUtility.ToJson(newData);
        File.WriteAllText(savedFilelevel, jsonString);
        Debug.Log("File saved");
    }

    public void SaveData(){
        if (player  == null)
        {
            return;
        }
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<LifeManager>().playerLife
        };
        string jsonString = JsonUtility.ToJson(newData);
        File.WriteAllText(savedFile, jsonString);
        Debug.Log("File saved");
    }

    public void SaveDataManually(Vector3 pos)
    {
        GameData newData = new GameData()
        {
            position = pos,
            health = 3
        };
        string jsonString = JsonUtility.ToJson(newData);
        File.WriteAllText(savedFile, jsonString);
        Debug.Log("File saved");
    }

    public void SaveGame(){
        SaveData();
    }
}

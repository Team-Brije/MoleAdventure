using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour
{
    public GameObject player;
    public string savedFile;
    public GameData gameData = new GameData();
    void Awake(){
        savedFile = Application.dataPath + "/gameData.json";
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
            Debug.Log("Player position: " + gameData.position);
            player.transform.position = gameData.position;
            player.GetComponent<LifeManager>().playerLife = gameData.health;
        }else{
            Debug.Log("The File does not exist");
        }
    }
    public void SaveData(){
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<LifeManager>().playerLife
        };
        string jsonString = JsonUtility.ToJson(newData);
        File.WriteAllText(savedFile, jsonString);
        Debug.Log("File saved");
    }
    public void SaveGame(){
        SaveData();
    }
}

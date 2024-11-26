using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string menuSceneName;
    public GameDataController gameDataController;
    public void MainMenu(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(menuSceneName);
    }
    public void SaveBttn(){
        gameDataController.SaveGame();
    }
}

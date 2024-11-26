using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePaussed : MonoBehaviour
{
    public GameObject pauseMenu;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if(pauseMenu.activeSelf){
                Time.timeScale = 0.0f;
            }else{
                Time.timeScale = 1.0f;
            }
        }
    }
}

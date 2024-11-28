using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpdater : MonoBehaviour
{
    public GameDataController controller;
    public int leveltogoInt;
    public string levelName;
    public Vector3 newpos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.SaveLevel(leveltogoInt);
            controller.SaveDataManually(newpos);
            SceneManager.LoadScene(levelName);
        }
    }
}

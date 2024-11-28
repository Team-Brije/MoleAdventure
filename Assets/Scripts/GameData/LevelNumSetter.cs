using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumSetter : MonoBehaviour
{
    public GameDataController controller;
    int level;
    public enum ButtonType { Start,Continue }
    public ButtonType type;
    Button button;
    public Vector3 pos;
    
    void Start()
    {
        button = GetComponent<Button>();
        level = controller.LoadLevel();
        if (type == ButtonType.Continue && level != 0)
        {
            button.interactable = true;
        }
    }

    public void setButton(int lvl)
    {
        controller.SaveDataManually(pos);
        controller.SaveLevel(lvl);
    }
}

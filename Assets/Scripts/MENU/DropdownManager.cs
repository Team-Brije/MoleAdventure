using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    private FullScreenMode mode = FullScreenMode.ExclusiveFullScreen;
    private int resx = 1920, resy = 1080;
    private string _resolution = "ScrenResolution";
    private string _screenType = "ScreenType";

    void Start()
    {
        if (!PlayerPrefs.HasKey(_resolution))
        {
            PlayerPrefs.SetInt(_resolution, 0);
            Load();
        }
        else
        {
            Load();
        }
        if (!PlayerPrefs.HasKey(_screenType))
        {
            PlayerPrefs.SetInt(_screenType, 3);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void Load()
    {
        int screen, type;
        screen = PlayerPrefs.GetInt(_resolution);
        type = PlayerPrefs.GetInt(_screenType);
        ChangeFullscreenBehaviour(type);
        ChangeResolution(screen);
    }

    public void Save(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }

    public void ChangeFullscreenBehaviour(int val)
    {
        if (val == 0)
        {
            mode = FullScreenMode.ExclusiveFullScreen;
            Save(_screenType, val);
            ResChange();
        }
        if (val == 1)
        {
            mode = FullScreenMode.FullScreenWindow;
            Save(_screenType,val);
            ResChange();
        }
        if (val == 2)
        {
            mode = FullScreenMode.Windowed;
            Save(_screenType,val);
            ResChange();
        }
    }

    public void ChangeResolution(int val)
    {
        if (val == 0)
        {
            resx = 4096;
            resy = 2160;
            Save(_resolution, val);
            ResChange();
        }
        if (val == 1)
        {
            resx = 2560;
            resy = 1440;
            Save(_resolution,val);
            ResChange();
        }
        if (val == 2)
        {
            resx = 1440;
            resy = 900;
            Save(_resolution,val);
            ResChange();
        }
        if (val == 3)
        {
            resx = 1920;
            resy = 1080;
            Save(_resolution,val);
            ResChange();
        }
        if (val == 4)
        {
            resx = 1366;
            resy = 768;
            Save(_resolution,val);
            ResChange();
        }
        if (val == 5)
        {
            resx = 1280;
            resy = 1024;
            Save(_resolution,val);
            ResChange();
        }
        if (val == 6)
        {
            resx = 1024;
            resy = 768;
            Save(_resolution,val);
            ResChange();
        }
    }

    public void ResChange()
    {
        Screen.SetResolution(resx, resy, mode);
    }
}

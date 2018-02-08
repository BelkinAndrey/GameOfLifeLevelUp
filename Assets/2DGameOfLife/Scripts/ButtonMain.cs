using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : MonoBehaviour {

    int W = 800;
    int H = 600;

    Resolution[] resolutions;

    public GameObject panel;

    void Start()
    {
        resolutions = Screen.resolutions;
    }


    public void ButtonClose() 
    {
        Application.Quit();
    }

    public void ButtonFullScreen() 
    {
        if (!Screen.fullScreen)
        {
            W = Screen.width;
            H = Screen.height;
            Screen.fullScreen = true;
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
        }
        else
        {
            Screen.fullScreen = false;
            Screen.SetResolution(W, H, false);
        }
    }

    public void ButtonInterface() 
    {
        if (panel.active) panel.SetActive(false);
        else panel.SetActive(true);
    }
}

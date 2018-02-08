using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaxText : MonoBehaviour {

    public Material material;
    public Slider slider;

    void Start() 
    {
        material.SetInt("_MaxLevel", (int)slider.value);
    }
    public void Change() 
    {
        gameObject.GetComponent<Text>().text = "Max: " + slider.value;
        material.SetInt("_MaxLevel", (int)slider.value);
    }

}

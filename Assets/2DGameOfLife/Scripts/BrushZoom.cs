using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushZoom : MonoBehaviour {

    public Slider slider;

    public void Change() 
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(slider.value, slider.value);
    }
	
}

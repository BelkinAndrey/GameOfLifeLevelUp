using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleKilMax : MonoBehaviour {

    public Material material;

    void Start() 
    {
        Change();
    }

    public void Change() 
    {
        material.SetInt("_KillMaxUp", gameObject.GetComponent<Toggle>().isOn ? 1 : 0);
    }
}

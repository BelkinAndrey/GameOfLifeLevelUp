using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCA : MonoBehaviour {

	public Material material;

    public void Change (string toggleName)
	{
        material.SetInt(toggleName, GameObject.Find(toggleName).GetComponent<Toggle>().isOn ? 1 : 0);
	}
}

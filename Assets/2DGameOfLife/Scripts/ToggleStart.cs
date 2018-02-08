using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStart : MonoBehaviour {

    public Material material;

	void Start () {

        material.SetInt(gameObject.name, gameObject.GetComponent<Toggle>().isOn ? 1 : 0);

	}
	
}

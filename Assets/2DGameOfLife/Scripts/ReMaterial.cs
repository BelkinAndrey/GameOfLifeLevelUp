using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReMaterial : MonoBehaviour {

    public Material material;
    public MeshRenderer plane;

    public void NewMaterial() 
    {
        plane.material = material;
    }
}

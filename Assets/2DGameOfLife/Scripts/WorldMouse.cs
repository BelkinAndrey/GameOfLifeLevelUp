using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMouse : MonoBehaviour {

    int x, y;
    int r;
    public Text XText;
    public Text YText;
    public Text rText;

    public Slider slader;

    public RenderTexture renderTexture;

    void Update() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit))
             return;

        Vector2 localPoint = hit.textureCoord;
        x = (int)(localPoint.x * 1000);
        y = (int)(localPoint.y * 1000);

        RenderTexture.active = renderTexture;

        Texture2D tex = new Texture2D(1, 1);
        tex.ReadPixels(new Rect(x, renderTexture.height - y - 1, 1, 1), 0, 0);
        tex.Apply();
   
        r = (int)(tex.GetPixel(0, 0).r * slader.value);

        RenderTexture.active = null;

    }

    void OnGUI() 
    {
        XText.text = "X: " + x;
        YText.text = "Y: " + y;
        rText.text = "Level: " + r; 
    }
}

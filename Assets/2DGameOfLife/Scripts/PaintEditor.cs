using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintEditor : MonoBehaviour {

    int x, y;

    public Toggle brush;
    public Toggle eraser;
    public Toggle pencil;

    public Slider slider;
    public Slider sliderMax;

    public RenderTexture renderTexture;

    public Texture Clear;
    public Texture Brush;



    void Update() 
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit))
                return;

            Vector2 localPoint = hit.textureCoord;
            x = (int)(localPoint.x * 1000);
            y = (int)(localPoint.y * 1000);
            y = renderTexture.height - y - 1;

            if (brush.isOn)
            {
                BrushPaint();
                return;
            }

            if (eraser.isOn)
            {
                ClearPaint();
                return;
            }

            if (pencil.isOn)
            {
                PencilPaint();
                return;
            }
        }
    }

    void BrushPaint() 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        RenderTexture.active = renderTexture;

        int positionx = x - ((int)slider.value);
        int positiony = y - ((int)slider.value);
        Graphics.DrawTexture(new Rect(positionx, positiony, (int)slider.value * 2, (int)slider.value * 2), Brush);

        RenderTexture.active = null;

        GL.PopMatrix();
    }

    void ClearPaint() 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        RenderTexture.active = renderTexture;

        int positionx = x - ((int)slider.value);
        int positiony = y - ((int)slider.value);
        Graphics.DrawTexture(new Rect(positionx, positiony, (int)slider.value * 2, (int)slider.value * 2), Clear);

        RenderTexture.active = null;

        GL.PopMatrix();
    }

    void PencilPaint() 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        RenderTexture.active = renderTexture;

        Texture2D tex = new Texture2D(1, 1);
        tex.ReadPixels(new Rect(x, y, 1, 1), 0, 0);
        tex.Apply();

        float r = tex.GetPixel(0, 0).r;
        r += 1 / sliderMax.value;

        tex.SetPixel(0, 0, new Color(r, 1, 1, 1));
        tex.Apply();

        Graphics.DrawTexture(new Rect(x, y, 1, 1), tex);

        RenderTexture.active = null;

        GL.PopMatrix();
    }
}

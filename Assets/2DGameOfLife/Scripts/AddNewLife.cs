using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewLife : MonoBehaviour {

    public Texture newLife;
    public RenderTexture renderTexture;

    private bool DownButton = false;

	// Update is called once per frame
	public void ButtonDown () 
    {
        DownButton = true;
    }

    public void ButtonUp()
    {
        DownButton = false;
    }

    private void RunAddnewLife() 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        RenderTexture.active = renderTexture;
        int positionx, positiony;
        positionx = Random.Range(0, renderTexture.width + newLife.width + newLife.width) - newLife.width;
        positiony = Random.Range(0, renderTexture.height + newLife.height + newLife.height) - newLife.height;
        Graphics.DrawTexture(new Rect(positionx, positiony, newLife.width, newLife.height), newLife);
        RenderTexture.active = null;

        GL.PopMatrix();
    }

    public void ButtonClear() 
    {
        RenderTexture.active = renderTexture;

        GL.Clear(true, true, Color.black);

        RenderTexture.active = null;
    }

    void Update() 
    {
        if (DownButton) RunAddnewLife();
    }

    public void RandomButton()
    {
        Texture2D texture = new Texture2D(1000, 1000);
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = new Color(Random.Range(0, 10) == 0 ? Random.Range(0, 1f) : 0, 0, 0, 0);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();

        RenderTexture.active = renderTexture;
        Graphics.Blit(texture, renderTexture);
        RenderTexture.active = null;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveOpenPNG : MonoBehaviour {

    public RenderTexture renderTexture;

    public void SavePNG() 
    {
        RenderTexture.active = renderTexture;

        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();

        var bytes = tex.EncodeToPNG();
        Destroy(tex);

        File.WriteAllBytes(Application.dataPath + "/Data/" + "Save.png", bytes);

        RenderTexture.active = null;
    }

    public void OpenPNG() 
    {
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/Data/Save.png");
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height);
        tex.LoadImage(bytes);
        tex.Apply();

        Graphics.Blit(tex, renderTexture);
    }
}

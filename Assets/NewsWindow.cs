using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class NewsWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private TextMeshPro titleText;
    [SerializeField]
    private TextMeshPro summaryText;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTitle(string text)
    {
        titleText.text = text;
    }
    public void SetSummary(string text)
    {
        summaryText.text = text;
    }

    public void SetImage(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        DownloadHandlerTexture textureDl = new DownloadHandlerTexture(true);
        request.downloadHandler = textureDl;
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D t = textureDl.texture;

            // RectTransform rt = (RectTransform)spriteRenderer.transform;
            // rt.localScale = new Vector3(0.0005f, 0.0005f, 1f);
            // RectTransform rt = (RectTransform)spriteRenderer.transform;
            // int width = Mathf.FloorToInt(Mathf.Abs(rt.rect.xMax - rt.rect.xMin));
            // int height = Mathf.FloorToInt(Mathf.Abs(rt.rect.yMax - rt.rect.yMin));
            // Texture2D scaledTexture = ScaleTexture(t, width, height);
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),
                           Vector2.zero, 60f);


            spriteRenderer.sprite = s;
            spriteRenderer.transform.localScale = new Vector3(0.07045791f, 0.08344996f, 1);

            // spriteRenderer.bounds.SetMinMax(new Vector3(rt.rect.xMin, rt.rect.yMin, 0), new Vector3(rt.rect.xMax, rt.rect.yMax, 0));
            // ScaleImage(rt);
        }
        else
        {
            Debug.Log(request.error);
        }


    }

    // private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    // {
    //     Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);
    //     float incX = (1.0f / (float)targetWidth);
    //     float incY = (1.0f / (float)targetHeight);
    //     for (int i = 0; i < result.height; ++i)
    //     {
    //         for (int j = 0; j < result.width; ++j)
    //         {
    //             Color newColor = source.GetPixelBilinear((float)j / (float)result.width, (float)i / (float)result.height);
    //             result.SetPixel(j, i, newColor);
    //         }
    //     }
    //     result.Apply();
    //     return result;
    // }

}

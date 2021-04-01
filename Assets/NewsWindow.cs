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

            RectTransform rt = (RectTransform)spriteRenderer.transform;
            rt.localScale = new Vector3(0.0005f, 0.0005f, 1f);
            // RectTransform rt = (RectTransform)spriteRenderer.transform;
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),
                           Vector2.zero, 1f);

            spriteRenderer.sprite = s;
            spriteRenderer.bounds.SetMinMax(new Vector3(rt.rect.xMin, rt.rect.yMin, 0), new Vector3(rt.rect.xMax, rt.rect.yMax, 0));
        }
        else
        {
            Debug.Log(request.error);
        }


    }

    // public void ScaleImage(RectTransform rt){
    //      var topRightCorner =  Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    //     var worldSpaceWidth = topRightCorner.x * 2;
    //     var worldSpaceHeight = topRightCorner.y * 2;

    //     var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

    //     var scaleFactorX = worldSpaceWidth / spriteSize.x;
    //     var scaleFactorY = worldSpaceHeight / spriteSize.y;

    //         // handle aspect ratio
    //         if (scaleFactorX > scaleFactorY)
    //         {
    //             scaleFactorY = scaleFactorX;
    //         }
    //         else
    //         {
    //             scaleFactorX = scaleFactorY;
    //         }


    //     gameObject.transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
    // }

}

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
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.Log(request.error);
        }


    }
}

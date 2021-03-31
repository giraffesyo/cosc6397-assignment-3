using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class News : MonoBehaviour
{
    // Start is called before the first frame update
    private string newsUrl = "";
    // TODO: Move this into something outside of source control, then regenerate the key
    private string apiKey = "NgpxoU6OJ5RkRDV6ETWa7B66p4fSNWgy";
    private string ticker = "AAPL";
    private List<NewsItem> newsList;
    void Start()
    {
        newsUrl = $"https://api.polygon.io/v1/meta/symbols/{ticker}/news?perpage=50&page=1&apiKey={apiKey}";
        StartCoroutine(GetNews());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GetNews()
    {
        UnityWebRequest newsWr = UnityWebRequest.Get(newsUrl);
        yield return newsWr.SendWebRequest();
        if (newsWr.result == UnityWebRequest.Result.Success)
        {
            string json = newsWr.downloadHandler.text;
            var newsItems = JsonConvert.DeserializeObject<NewsItem[]>(json);
            newsList = new List<NewsItem>(newsItems);
            // newsList = new List<NewsRequest>(newsArr);
        }
        else
        {
            // there was an error...
        }
    }
}

[System.Serializable]
public class NewsItem
{
    public string summary;
    public string url;
    public string timestamp;
    public string title;
    public string source;
}
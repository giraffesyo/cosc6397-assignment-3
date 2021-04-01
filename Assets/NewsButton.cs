using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class NewsButton : MonoBehaviour
{
    // Start is called before the first frame update

    private NewsItem news;
    //TODO: Generate this window later so we can have multiple news windows open
    private NewsWindow newsWindow;
    void Start()
    {
        newsWindow = FindObjectOfType<NewsWindow>();
    }

    public void SetNewsItem(NewsItem item)
    {
        news = item;
        // Interactable interactable = GetComponent<Interactable>();
        // interactable.AddReceiver<InteractableOnTouchReceiver>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewsButtonTouched()
    {
        newsWindow.SetTitle(news.title);
        newsWindow.SetSummary(news.summary);
        newsWindow.SetImage(news.image);
    }
}

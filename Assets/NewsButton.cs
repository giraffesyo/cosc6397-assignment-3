using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class NewsButton : MonoBehaviour
{
    // Start is called before the first frame update

    private NewsItem news;
    void Start()
    {

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
        Debug.Log("news item clicked");
    }
}

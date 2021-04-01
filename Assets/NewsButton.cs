using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class NewsButton : MonoBehaviour
{
    // Start is called before the first frame update

    private NewsItem news;
    private bool open = false;
    //TODO: Generate this window later so we can have multiple news windows open
    private NewsWindow newsWindow;
    [SerializeField]
    private Transform upperLeftBounds;
    [SerializeField]
    private Transform lowerRightBounds;
    public GameObject NewsWindowPrefab;
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
        if (!open)
        {
            float xPos = Random.Range(upperLeftBounds.position.x, lowerRightBounds.position.x);
            float yPos = Random.Range(upperLeftBounds.position.y, lowerRightBounds.position.y);
            Vector3 newsWindowPostion = new Vector3(xPos, yPos, 0);
            GameObject sceneContent = GameObject.Find("SceneContent");
            GameObject newsWindowObj = Instantiate(NewsWindowPrefab, sceneContent.transform);
            newsWindowObj.transform.position = newsWindowPostion;
            newsWindow = newsWindowObj.GetComponent<NewsWindow>();
            newsWindow.SetTitle(news.title);
            newsWindow.SetSummary(news.summary);
            newsWindow.SetImage(news.image);
        }
        open = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Review : MonoBehaviour
{
    public static UI_Review Instance;

    public Transform ScrollParent;
    public UI_ReviewItem Prefab;

    public List<UI_ReviewItem> Items;
    
    private void Awake()
    {
        Instance = this;
        
        GetComponent<CanvasGroup>().alpha = 1;
        
        gameObject.SetActive(false);
    }

    public void Refresh()
    {
        var list = ReviewManager.Instance.Data;
        int itemCount = Items.Count;
        int listCount = list.Count;

        if (itemCount < listCount)
        {
            int diff = listCount - itemCount;

            for (int i = 0; i < diff; ++i)
            {
                var item = Instantiate<UI_ReviewItem>(Prefab);
                item.transform.SetParent(ScrollParent);
                item.GetComponent<RectTransform>().localScale = Vector3.one;

                Items.Add(item);
            }

            itemCount = Items.Count;
        }

        for (int i = 0; i < itemCount; ++i)
        {

            if (i >= listCount)
            {
                Items[i].gameObject.SetActive(false);
                continue;
            }
            
            Items[i].gameObject.SetActive(true);
            Items[i].Init(list[i]);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);

        ReviewManager.Instance.LoadList();
        
        ReviewManager.Instance.OnChangeCallback += Refresh;

        Refresh();
    }

    public void Close()
    {
        ReviewManager.Instance.OnChangeCallback -= Refresh;
        
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CatList : MonoBehaviour
{
    public static UI_CatList Instance;

    public Transform ScrollParent;
    public UI_CatListItem Prefab;

    public List<UI_CatListItem> Items;
    
    private void Awake()
    {
        Instance = this;
        
        GetComponent<CanvasGroup>().alpha = 1;
        
        gameObject.SetActive(false);
    }

    public void Refresh()
    {
        var list = CatListManager.Instance.Data;
        int itemCount = Items.Count;
        int listCount = list.Count;

        if (itemCount < listCount)
        {
            int diff = listCount - itemCount;

            for (int i = 0; i < diff; ++i)
            {
                var item = Instantiate<UI_CatListItem>(Prefab);
                item.transform.SetParent(ScrollParent);
                
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

        CatListManager.Instance.LoadList();
        
        CatListManager.Instance.OnChangeCallback += Refresh;

        Refresh();
    }

    public void Close()
    {
        CatListManager.Instance.OnChangeCallback -= Refresh;
        
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Review : MonoBehaviour
{
    public static UI_Review Instance;

    public Transform ScrollParent;
    public UI_ReviewItem Prefab;

    public List<UI_ReviewItem> Items;

    public InputField m_NameInputField;
    public InputField m_ContentInputField;
    public Button m_UploadButton;
    
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

    public void OnChangeText(string text)
    {
        m_UploadButton.interactable = m_NameInputField.text != string.Empty && m_ContentInputField.text != string.Empty;
    }
    
    public void OnClickUpload()
    {


        Upload(m_NameInputField.text, m_ContentInputField.text);
            
        m_NameInputField.text = string.Empty;
        m_ContentInputField.text = string.Empty;
    }
    public async UniTaskVoid Upload(string name, string content)
    {
        Debug.Log("리뷰 작성 요청");
        var response = await NetManager.Post<ResponseReviewInsertPacket>(new RequestReviewInsertPacket(name, content));

        if (response.result)
        {
            ReviewManager.Instance.LoadList();
        }
    }
    
}

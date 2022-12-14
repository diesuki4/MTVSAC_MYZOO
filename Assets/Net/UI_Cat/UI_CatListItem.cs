using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_CatListItem : MonoBehaviour
{ 
    private CatListResponseData m_Data;

    public RawImage m_RawImage;
    public GameObject m_NewObject;
    public Text m_TitleText;
    public Text m_DescriptionText;
        

    public void Init(CatListResponseData data)
    {
        m_Data = data;

        Set();
    }

    private void Set()
    {
        if (m_Data == null)
        {
            return;
        }

        StartCoroutine(DownloadImage(m_Data.imgUrl));
        Debug.LogError(m_Data.imgUrl);
        m_TitleText.text = m_Data.catName;
        m_DescriptionText.text = $"#{m_Data.species} #{m_Data.age}years #{m_Data.gender}";
    }
    
    IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            m_RawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    } 
}

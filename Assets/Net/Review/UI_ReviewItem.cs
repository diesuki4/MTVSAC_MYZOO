using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReviewItem : MonoBehaviour
{
    private ReviewData m_Data;
    public Text m_NameText;
    public Text m_ContentText;

    public void Init(ReviewData data)
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

        m_NameText.text = m_Data.name;
        m_ContentText.text = m_Data.context;
    }
}

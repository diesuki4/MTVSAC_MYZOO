using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Top : MonoBehaviour
{
    public void OnClickMenuButton()
    {
        
    }

    public void OnClickReviewButton()
    {
        UI_Review.Instance.Open();
    }
    
    public void OnClickCatListButton()
    {
        UI_CatList.Instance.Open();
    }

    public void OnClickSettingButton()
    {
        
    }
}

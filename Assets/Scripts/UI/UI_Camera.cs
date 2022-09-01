using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Camera : MonoBehaviour
{
    public static UI_Camera Instance;

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        
        Instance = this;
    }

    public void Show()
    {
        CameraManager.Instance.CameraOn();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


    public void OnClickShotButton()
    {
        
    }
}

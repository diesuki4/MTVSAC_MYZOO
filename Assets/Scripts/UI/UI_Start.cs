using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Start : MonoBehaviour
{
    public static UI_Start Instance;

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        
        Instance = this;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClickCameraButton()
    {
        //         CameraManager.Instance.CameraOn();

        UIManager.Instance.SetGameState(GameState.Camera);
    }
}

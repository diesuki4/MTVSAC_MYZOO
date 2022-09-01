using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public static UI_Main Instance;

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

    public Text HelloText;
    public Text InfoText;

    void RefreshUI()
    {
        HelloText.text = "안녕, " + GameManager.Instance.Name;
        InfoText.text = "#" + GameManager.Instance.Species + " #" + GameManager.Instance.Age + "살 #" + GameManager.Instance.Gender;
    }
}

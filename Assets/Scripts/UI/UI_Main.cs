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

    public void OnClickSaveButton()
    {
        Save();
    }

    private async UniTaskVoid Save()
    {
        RequestSavePacket packet = new RequestSavePacket();

        packet.catIndex = GameManager.Instance.CatIndex;
        packet.affection = GameManager.Instance.Affection;
        packet.starvation = GameManager.Instance.Starvation;
        packet.cleanliness = GameManager.Instance.Cleanliness;

        var response = await NetManager.Post<ResponseSavePacket>(packet);
        Debug.LogError(response.result);
    }
}

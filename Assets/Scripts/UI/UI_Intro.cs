using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Intro : MonoBehaviour
{
    public static UI_Intro Instance;

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        
        Instance = this;
    }

    public void Show()
    {
        gameObject.SetActive(true);

        Auth();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private async UniTaskVoid Auth()
    {
        var response = await NetManager.Post<ResponseAuthPacket>(new RequestAuthPacket());
        Debug.LogError(response.data);
        if (response.result)
        {
            Debug.LogError(response.data);

            var data = response.data;

            GameManager.Instance.Affection = data.affection;
            GameManager.Instance.Starvation = data.starvation;
            GameManager.Instance.Cleanliness = data.cleanliness;
            GameManager.Instance.CatIndex = data.catIndex;
            GameManager.Instance.Species = data.species;
            GameManager.Instance.Age = data.age;
            GameManager.Instance.Name = data.catName;
            GameManager.Instance.Gender = data.gender;

            UIManager.Instance.SetGameState(GameState.Lobby);
            return;
        }
        
        UIManager.Instance.SetGameState(GameState.Camera);
    }
}

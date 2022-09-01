using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : MonoBehaviour
{
    public static UI_Lobby Instance;

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        
        Instance = this;
    }

    public Transform light;
    public GameObject lobbyCat;

    void OnEnable()
    {
        light.eulerAngles = new Vector3(28.229f, 149.548f, 179.703f);
        lobbyCat.SetActive(true);
    }

    void OnDisable()
    {
        light.eulerAngles = new Vector3(50, -30, 0);
        lobbyCat.SetActive(false);
    }

    public void Show()
    {
        RefreshUI();
        
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public Text HelloText;
    public Text InfoText;
    public Text CatCareText;

    void RefreshUI()
    {
        HelloText.text = "안녕, " + GameManager.Instance.Name;
        InfoText.text = "#" + GameManager.Instance.Species + " #" + GameManager.Instance.Age + "살 #" + GameManager.Instance.Gender;
        CatCareText.text = GameManager.Instance.Name + " 돌보기 가기";
    }

    public void OnNextSceneButtonClick()
    {
        UIManager.Instance.SetGameState(GameState.Main);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Affection;
    public int Starvation;
    public int Cleanliness;
    public int CatIndex;
    public string Species;
    public int Age;
    public string Name;
    public string Gender;

    public byte[] catImage;

    public Action OnChangeCallback;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(OneSecondTick());
        StartCoroutine(TwoSecondTick());
    }


    private IEnumerator OneSecondTick()
    {
        var wait = new WaitForSeconds(1f);

        while (true)
        {
            yield return wait;

            if (UIManager.Instance.GameState == GameState.Main)
            {
                Affection -= 1;

                OnChangeCallback?.Invoke();
            }
        }
    }
    
    private IEnumerator TwoSecondTick()
    {
        var wait = new WaitForSeconds(2f);

        while (true)
        {
            yield return wait;

            if (UIManager.Instance.GameState == GameState.Main)
            {
                Starvation -= 1;
                Cleanliness -= 1;


                OnChangeCallback?.Invoke();
            }
        }
    }

    private IEnumerator OneMinuteTick()
    {
        var wait = new WaitForSeconds(60f);

        while (true)
        {
            yield return wait;

            if (UIManager.Instance.GameState == GameState.Main)
            {
                Save();

                OnChangeCallback?.Invoke();
            }
        }
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

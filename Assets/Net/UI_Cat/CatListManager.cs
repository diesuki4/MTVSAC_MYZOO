using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;

public class CatListManager : MonoBehaviour
{
    public static CatListManager Instance;

    public Action OnChangeCallback;

    
    private List<CatListResponseData> m_Data = new List<CatListResponseData>(32);
    public List<CatListResponseData> Data => m_Data;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadList();
    }

    public async UniTaskVoid LoadList()
    {
        Debug.Log("고양이 이미지 리스트 요청");
        var response = await NetManager.Post<ResponseCatListPacket>(new RequestCatListPacket());

        if (response.result)
        {
            m_Data.Clear();

            var catDataList = response.results;

            for (int i = 0; i < catDataList.Length; ++i)
            {
                m_Data.Add(catDataList[i]);
            }
            
            Debug.LogError(m_Data.Count);
            
            OnChangeCallback?.Invoke();
        }
    }
}

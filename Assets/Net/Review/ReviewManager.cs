using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ReviewManager : MonoBehaviour
{
    public static ReviewManager Instance;

    public Action OnChangeCallback;
    
    private List<ReviewData> m_Data = new List<ReviewData>(32);
    public List<ReviewData> Data => m_Data;
    
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
        Debug.Log("리뷰 리스트 요청");
        var response = await NetManager.Post<ResponseReviewLoadPacket>(new RequestReviewLoadPacket());

        if (response.result)
        {
            m_Data.Clear();

            var reviewList = response.data;

            for (int i = 0; i < reviewList.Length; ++i)
            {
                m_Data.Add(reviewList[i]);
            }
            
            Debug.LogError(m_Data.Count);
            
            OnChangeCallback?.Invoke();
        }
    }
}

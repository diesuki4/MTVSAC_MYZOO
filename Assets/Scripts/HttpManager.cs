using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpManager : MonoBehaviour
{
    public static HttpManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public const string SERVER_ADDR = "http://192.168.1.59:8888";
    
    void Start() { }
    void Update() { }

    public void SendRequest(HttpRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HttpRequester requester)
    {
        UnityWebRequest webRequest = null;

        switch (requester.requestType)
        {
            case RequestType.GET :
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.POST :
                webRequest = UnityWebRequest.Post(requester.url, requester.formData);
                break;
        }

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success &&
            requester.onComplete != null)
            requester.onComplete(webRequest.downloadHandler);
        else
            Debug.Log("[FAIL] : " + webRequest.result + " (" + webRequest.error + ")");
        
        yield return null;
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class C_UIManager : MonoBehaviour
{
    public static C_UIManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public const string SERVER_ADDR = "http://192.168.1.59:8888";

    void Start() { }
    void Update() { }

    public void OnClickBtn_GET()
    {
        string url = SERVER_ADDR + "/test";
        HttpRequester requester = new HttpRequester();

        requester.url = url;
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteBtn_GET;

        HttpManager.Instance.SendRequest(requester);
    }

    public void OnCompleteBtn_GET(DownloadHandler handler)
    {
        MyCat data = JsonUtility.FromJson<MyCat>(handler.text);

        Debug.Log("[TODO] " + data.myCatNum + "\n" + data.saveData + "\n" + data.catId);
    }
/*
    public void OnClickBtnAll_GET()
    {
        string url = SERVER_ADDR + "/test";
        HttpRequester requester = new HttpRequester();

        requester.url = url;
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteBtnAll_GET;

        HttpManager.Instance.SendRequest(requester);
    }

    public void OnCompleteBtnAll_GET(DownloadHandler handler)
    {
        string s = "{\"data\":" + handler.text + "}";
    
        Test_GETArray array = JsonUtility.FromJson<Test_GETArray>(s);
        
        foreach (Test_GET data in array.data)
            Debug.Log("[TODO] " + data.id + "\n" + data.title + "\n" + data.body);
    }
*/
    public void OnClickBtn_POST()
    {
        string url = SERVER_ADDR + "/test";
        HttpRequester requester = new HttpRequester();

        requester.url = url;
        requester.requestType = RequestType.POST;

        CatImageRaw data = new CatImageRaw();
        data.imageRaw = File.ReadAllBytes(Application.dataPath + "/" + "cat.png");
        data.takenLocation = "aaaaaa";

        WWWForm form = new WWWForm();
        form.AddBinaryData("image", data.imageRaw, "cat.png", "image/png");
        form.AddField("takenLocation", data.takenLocation);

        requester.formData = form;
        requester.onComplete = OnCompleteBtn_POST;

        HttpManager.Instance.SendRequest(requester);
    }

    public void OnCompleteBtn_POST(DownloadHandler handler)
    {
        Debug.Log("[OnCompleteBtn_POST] 이미지 업로드 완료");
    }

    public void OnClickLogin()
    {
        string url = SERVER_ADDR + "/test";
        HttpRequester requester = new HttpRequester();

        UserInfo.Instance.deviceId = SystemInfo.deviceUniqueIdentifier;

        string param = "?";
        param += "deviceId=" + UserInfo.Instance.deviceId;

        requester.url = url + param;
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteLogin;

        HttpManager.Instance.SendRequest(requester);
    }

    void OnCompleteLogin(DownloadHandler handler)
    {
        string result = handler.text;

        if (result == "false")
            Debug.Log("[TODO] 신규 유저이므로 고양이 사진 찍고 서버에 저장하기");
        else
            LoadMyCatDataToUI(JsonUtility.FromJson<MyCat>(result));
    }

    void LoadMyCatDataToUI(MyCat myCat)
    {
        Debug.Log("[TODO] MyCat 을 UI 에 표시하기");
    }
}

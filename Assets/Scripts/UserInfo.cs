using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance;

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

    public string deviceId;
    public string catid;
    public byte[] catImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickBtn_POST()
    {
        string url = HttpManager.SERVER_ADDR + "/test";
        HttpRequester requester = new HttpRequester();

        requester.url = url;
        requester.requestType = RequestType.POST;

        CatImageRaw data = new CatImageRaw();
        data.imageRaw = UserInfo.Instance.catImage;
        data.takenLocation = "화성시 정남면 보통리 141-39";

        WWWForm form = new WWWForm();
        form.AddBinaryData("file", data.imageRaw);
        form.AddField("takenLocation", data.takenLocation);

        requester.formData = form;
        requester.onComplete = OnCompleteBtn_POST;

        HttpManager.Instance.SendRequest(requester);
    }

    public void OnCompleteBtn_POST(DownloadHandler handler)
    {
        MyCat data = JsonUtility.FromJson<MyCat>(handler.text);

        Debug.Log("[TODO] " + data.myCatNum + "\n" + data.saveData + "\n" + data.catId);

        
    }
}

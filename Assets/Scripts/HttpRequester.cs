using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum RequestType
{
    GET,
    POST
}

public class HttpRequester
{
    public string url;

    public RequestType requestType;

    public WWWForm formData;

    public Action<DownloadHandler> onComplete = null;
}

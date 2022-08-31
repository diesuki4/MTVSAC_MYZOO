using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatListResponseData
{
    public int index;
    public string title;
    public string imageUrl;
    public string description;
}

public class RequestCatListPacket : IRequestPacket
{
    public RequestCatListPacket() : base("catlist")
    {
        
    }
}

public class ResponseCatListPacket : ResponsePacket
{
    public CatListResponseData[] data { get; private set; }
}

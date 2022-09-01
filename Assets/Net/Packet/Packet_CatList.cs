using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatListResponseData
{
    public int imgIndex;
    public string imgUrl;
    public string imgDateTime;
    public string location;
}

public class RequestCatListPacket : IRequestPacket
{
    public RequestCatListPacket() : base("cats/catinfos")
    {
        
    }
}

public class ResponseCatListPacket : ResponsePacket
{
    public CatListResponseData[] results { get; private set; }
}

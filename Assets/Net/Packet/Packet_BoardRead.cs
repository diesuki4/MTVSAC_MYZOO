using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardReadResponseData
{
    public int index;
    public string title;
    public string deviceId;
    public string imageUrl;
    public string description;
}

public class RequestBoardReadPacket : IRequestPacket
{
    public RequestBoardReadPacket() : base("read")
    {
        
    }
}

public class ResponseBoardReadPacket : ResponsePacket
{
    
    public BoardListResponseData[] data { get; private set; }
}
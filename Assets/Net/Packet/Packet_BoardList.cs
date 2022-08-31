using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardListResponseData
{
    public int index;
    public string title;
    public string imageUrl;
    public string description;
}


public class RequestBoardListPacket : IRequestPacket
{
    public RequestBoardListPacket() : base("list")
    {
        
    }
}

public class ResponseBoardListPacket : ResponsePacket
{
    
    public BoardListResponseData[] data { get; private set; }
}

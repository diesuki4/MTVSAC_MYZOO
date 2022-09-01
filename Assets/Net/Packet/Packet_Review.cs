using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewData
{
    public string name;
    public string context;
}


public class RequestReviewInsertPacket : IRequestPacket
{
    public string name;
    public string context;
    
    public RequestReviewInsertPacket(string name, string context) : base("InsertBoard")
    {
        this.name = name;
        this.context = context;
    }
}

public class ResponseReviewInsertPacket : ResponsePacket
{
    
}


public class RequestReviewLoadPacket : IRequestPacket
{

    public RequestReviewLoadPacket() : base("LoadBoard")
    {
    }
}

public class ResponseReviewLoadPacket : ResponsePacket
{
    public ReviewData[] data;
}

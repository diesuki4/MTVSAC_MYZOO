using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 successfully","result":true,"data":{"mycatInfo":[{"catIndex":1,"species":"러시안블루","age":1,"catName":"호랭냥","gender":"암컷","affection":50,"starvation":50,"cleanliness":50}]}}
 */

public class RequestSavePacket : IRequestPacket
{
    public int catIndex;
    public int affection;
    public int starvation;
    public int cleanliness;

    public  RequestSavePacket() : base("cats/mycat")
    {   
        
    }
}

public class ResponseSavePacket : ResponsePacket
{
}
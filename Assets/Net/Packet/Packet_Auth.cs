using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 successfully","result":true,"data":{"mycatInfo":[{"catIndex":1,"species":"러시안블루","age":1,"catName":"호랭냥","gender":"암컷","affection":50,"starvation":50,"cleanliness":50}]}}
 */
public class MycatInfo
{
    public int catIndex;
    public string species;
    
    public int affection;
    public int starvation;
    public int cleanliness;
 
    public int age;
    public string catName;
    public string gender;
}

public class RequestAuthPacket : IRequestPacket
{
    public string status;
    public string message;
    
    public  RequestAuthPacket() : base("cats/auth")
    {   
        
    }
}

public class ResponseAuthPacket : ResponsePacket
{
    public MycatInfo data { get; private set; }
}
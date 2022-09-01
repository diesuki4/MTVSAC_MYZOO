using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycatInfo
{
    public int affection;
    public int starvation;
    public int cleanliness;
    public int catIndex;
    public string species;
    public int age;
    public string name;
    public string gender;
}

public class RequestAuthPacket : IRequestPacket
{
    public  RequestAuthPacket() : base("auth")
    {   
        
    }
}

public class ResponseAuthPacket : ResponsePacket
{
    public List<MycatInfo> data { get; private set; }
}
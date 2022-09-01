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
<<<<<<< Updated upstream
    public  RequestAuthPacket() : base("cats/auth")
=======
    public RequestAuthPacket() : base("auth")
>>>>>>> Stashed changes
    {   
        
    }
}

public class ResponseAuthPacket : ResponsePacket
{
    public List<MycatInfo> data { get; private set; }
}
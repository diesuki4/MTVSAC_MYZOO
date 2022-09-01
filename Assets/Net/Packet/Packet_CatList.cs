using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 *
 species":"러시안블루","age":1,"catName":"호랭냥","gender":"암컷","imgUrl":"uploads\\20220831232511_cat.png","imgDatetime":"2022-08-31T15:00:00.000Z","location":"메타버스
 */
public class CatListResponseData
{
    public string imgUrl;
    public string imgDateTime;
    public string location;
    public string species;
    public int age;
    public string catName;
    public string gender;
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

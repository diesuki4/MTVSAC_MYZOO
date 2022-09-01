using System;
using System.Collections.Generic;

[Serializable]
public class MyCat
{
	public int myCatNum;
	public SaveData saveData;
	public int catId;
}

[Serializable]
public class SaveData
{

}

[Serializable]
public class MyCatArray
{
    public List<MyCat> array;
}

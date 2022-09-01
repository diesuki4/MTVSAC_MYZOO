using System;
using System.Collections.Generic;

[Serializable]
public class CatClass
{
	public int catId;
	public int catType;
	public int age;
	public string name;
	public string gender;
}

[Serializable]
public class CatClassArray
{
    public List<CatClass> array;
}

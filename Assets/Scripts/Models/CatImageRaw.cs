using System;
using System.Collections.Generic;

[Serializable]
public class CatImageRaw
{
	public byte[] imageRaw;
	public string takenLocation;
}

[Serializable]
public class CatImageRawArray
{
    public List<CatImageRaw> array;
}

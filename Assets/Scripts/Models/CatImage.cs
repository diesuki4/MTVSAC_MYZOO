using System;
using System.Collections.Generic;

[Serializable]
public class CatImage
{
	public string imagePath;
	public string takenLocation;
}

[Serializable]
public class CatImageArray
{
    public List<CatImage> array;
}

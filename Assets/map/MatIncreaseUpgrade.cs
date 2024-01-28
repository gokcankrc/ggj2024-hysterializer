using System;

[Serializable]
public class MatIncreaseUpgrade : Upgrade
{
	public MatType TargetMatType;
	public int Increment = 1;
}

using System;

public class Upgrade
{
	public string Text;
	public int LevelId;
}

public class MatIncreaseUpgrade : Upgrade
{
	public MatType TargetMatType;
	public int Increment = 1;
}

public class GunUnlockUpgrade : Upgrade
{
	public int GunIndex = 1;
}
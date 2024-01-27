

public class Effect
{
	public string Text;
	public int LevelId;
}

public class MatIncreaseEffect : Effect
{
	public MatType TargetMatType;
	public int Increment = 1;
}

public class GunUnlockEffect : Effect
{
	public int GunIndex = 1;
}
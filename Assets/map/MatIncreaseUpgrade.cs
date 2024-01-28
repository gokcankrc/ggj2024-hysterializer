using System;

[Serializable]
public class MatIncreaseUpgrade : Upgrade
{
	public MatType TargetMatType;
	public int Increment = 1;

	public override void Activate()
	{
		ResourcesManager.I.matMax[((int)TargetMatType)] += Increment;
	}

	public override string GetText()
	{

		return $"Gives {Increment} {TargetMatType}";
	}
}

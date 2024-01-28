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
		var a = new string[] { "zero", "one", "two", "three" };


		return $"Gives {a[Increment]} {TargetMatType}";
	}
}

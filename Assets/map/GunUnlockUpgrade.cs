using System;
using UnityEngine;

[Serializable]
public class GunUnlockUpgrade : Upgrade
{
	public int GunIndex = 1;

	public override void Activate()
	{
		ResourcesManager.I.GunLevel = (int)Mathf.Round(MathF.Max(ResourcesManager.I.GunLevel, GunIndex));
	}
}
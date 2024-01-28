

using System;
using System.Collections.Generic;
using System.Data;

[Serializable]
public class Effect
{
	public int PotencyAdd;
	public ResistanceTypes ResistancesPenetrated;

	public void Add(Effect effect)
	{
		PotencyAdd += effect.PotencyAdd;
		ResistancesPenetrated |= effect.ResistancesPenetrated;
	}

	public string GetBeingPower()
	{
		var text = $"Needs {PotencyAdd} potency\n";

		List<string> resistances = new List<string>();
		foreach (ResistanceTypes r in Enum.GetValues(typeof(ResistanceTypes)))
			if ((ResistancesPenetrated & r) != 0)
				resistances.Add(r.ToString());

		foreach (var resistance in resistances)
			text += $"{resistance}";
		return text;
	}

	public virtual int GetPotency()
	{
		return PotencyAdd;
	}
}

[Flags]
public enum ResistanceTypes
{
	None = 0,
	ThickSkin = 1,
	ColdSkin = 2,
	HotSkin = 4,
}
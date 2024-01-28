

using System;

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
}

[Flags]
public enum ResistanceTypes
{
	None = 0,
	ThickSkin = 1,
	ColdSkin = 2,
	HotSkin = 4,
}
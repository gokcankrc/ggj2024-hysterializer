

using System;

[Serializable]
public class Effect
{
	public string Text;
	public int PotencyAdd;
	public ResistanceTypes ResistancesPenetrated;
}

[Flags]
public enum ResistanceTypes
{
	None = 0,
	ThickSkin = 1,
	ColdSkin = 2,
	HotSkin = 4,
}
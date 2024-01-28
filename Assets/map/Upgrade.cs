using System;

[Serializable]
public abstract class Upgrade
{
	public string Text;

	public abstract void Activate();
}

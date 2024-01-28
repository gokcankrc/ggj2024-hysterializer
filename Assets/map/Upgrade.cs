using System;

[Serializable]
public abstract class Upgrade
{
	public abstract void Activate();
	public abstract string GetText();
}

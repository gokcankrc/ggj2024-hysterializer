using RegularDuck._Core.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
	public const int MatLength = 4;
	public int[] matMax = new int[MatLength];
	public int[] matDefaults = new int[MatLength];
	public int GunLevel;

	private void Start()
	{
		Load();
	}

	public void Load()
	{
		for (int i = 0; i < MatLength; i++)
			MapManager.I.AllMaps[i].TryLoad(i);

		PlayerPrefs.Save();
	}
	public void Save()
	{
		for (int i = 0; i < MatLength; i++)
			MapManager.I.AllMaps[i].TrySave(i);

		PlayerPrefs.Save();
	}
}

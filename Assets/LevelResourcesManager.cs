using RegularDuck._Core.Helpers;
using System;
using UnityEngine;

public class LevelResourcesManager : Singleton<LevelResourcesManager>
{
	public static int MatLength => ResourcesManager.MatLength;
	public static Action ResourcesRefresh;
	public int[] matCurrent = new int[MatLength];

	private void Start()
	{
		Debug.Log("teporary level resources set");
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = 5;
		ResourcesRefresh?.Invoke();
	}

	public void EnteringLevel()
	{
		GetCurrentMaxResources();
		ResourcesRefresh?.Invoke();
	}

	private void GetCurrentMaxResources()
	{
		var resMang = ResourcesManager.I;
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = resMang.matMax[i];
	}
}

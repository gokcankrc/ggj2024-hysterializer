using RegularDuck._Core.Helpers;
using UnityEngine;

public class LevelResourcesManager : Singleton<LevelResourcesManager>
{
	public static int MatLength => ResourcesManager.MatLength;
	public int[] matCurrent = new int[MatLength];

	private void Start()
	{
		Debug.Log("teporary level resources set");
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = 5;
	}

	public void EnteringLevel()
	{
		GetCurrentMaxResources();
	}

	private void GetCurrentMaxResources()
	{
		var resMang = ResourcesManager.I;
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = resMang.matMax[i];
	}
}

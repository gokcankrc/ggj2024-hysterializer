using RegularDuck._Core.Helpers;
using System;
using HexagonalGrid;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	public static int MatLength => ResourcesManager.MatLength;
	public static Action ResourcesRefresh;
	public int[] matCurrent = new int[MatLength];
	public HexagonSockets temporarySocktTarget;
	public Being Candidate;

	private void Start()
	{
		Debug.Log("teporary level resources set");
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = 5;
		ResourcesRefresh?.Invoke();
	}

	public void EnterInterview(MapButton map)
	{
		GetCurrentMaxResources();
		ResourcesRefresh?.Invoke();
		Candidate = map.Candidate;
		// Make portrey of candidate on the face

		GameManager.I.SwitchToGun();

		HexGrid.I.FillGrid();
		HexGrid.I.PlaceSocketsInGrid(temporarySocktTarget);
	}

	public void ShootGun()
	{
	}

	private void GetCurrentMaxResources()
	{
		var resMang = ResourcesManager.I;
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = resMang.matMax[i];
	}
}

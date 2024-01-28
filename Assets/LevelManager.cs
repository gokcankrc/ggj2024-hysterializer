using RegularDuck._Core.Helpers;
using System;
using HexagonalGrid;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : Singleton<LevelManager>
{
	public static int MatLength => ResourcesManager.MatLength;
	public static Action ResourcesRefresh;
	public int[] matCurrent = new int[MatLength];
	public List<HexagonSockets> Guns;
	public Being Candidate;
	public Transform GunVisualParent;

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
		MatSelectionManager.I.Deselect();
		ResourcesRefresh?.Invoke();
		Candidate = map.Candidate;
		// Make portrey of candidate on the face

		GameManager.I.SwitchToGun();

		HexGrid.I.FillGrid();
		HexagonSockets gun = Guns[ResourcesManager.I.GunLevel];
		HexGrid.I.PlaceSocketsInGrid(gun);
		var tr = HexGrid.I.transform;
		tr.localPosition = gun.OriginShift;
		var a = Instantiate(gun.GunVisual, GunVisualParent);
		gun.PlaceVisual(a.transform);
	}

	private void GetCurrentMaxResources()
	{
		var resMang = ResourcesManager.I;
		for (int i = 0; i < MatLength; i++)
			matCurrent[i] = resMang.matMax[i];
	}
}

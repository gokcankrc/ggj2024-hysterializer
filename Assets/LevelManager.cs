using RegularDuck._Core.Helpers;
using System;
using HexagonalGrid;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

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
		foreach (Transform child in GunVisualParent)
			Destroy(child.gameObject);

		HexagonSockets gun = Guns[MapManager.I.SelectedGunID];
		HexVector.XScale = gun.ScaleOverride;
		HexVector.YScale = gun.ScaleOverride;
		EnemyDescriptionHandler.I.SetEnemy(map.Candidate);
		var img = PortraitHandler.I.image;
		img.sprite = Candidate.Portrait;

		HexGrid.I.FillGrid();
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

	public void SetLaughingPortrait()
	{
		var a = PortraitHandler.I.image;
		a.sprite = Candidate.PortraitLaugh;
		SoundManager.Play(Candidate.LaughAudioClip);
	}
}

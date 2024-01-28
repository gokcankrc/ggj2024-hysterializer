using RegularDuck._Core.Helpers;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
	public TextMeshProUGUI SelectionText;
	public TextMeshProUGUI LockedText;
	public List<MapButton> AllMaps;
	public MapButton SelectedMap;
	public GameObject SelectionCircle;
	public int SelectedGunID;
	public GunSelection CurrentSelectedGun;


	protected override void Awake()
	{
		base.Awake();

		SelectionCircle.SetActive(false);
	}

	public void Deselect()
	{
		if (SelectedMap == null) return;
		SelectedMap.Deselect();
		SelectionCircle.SetActive(false);
	}

	public void Select(MapButton mapButton)
	{
		if (SelectedMap != null)
			SelectedMap.Deselect();
		SelectedMap = mapButton;
		LockedText.enabled = !SelectedMap.IsUnlocked;

		SelectionText.text = GetDescriptionText();
		SelectionCircle.SetActive(true);
		SelectionCircle.transform.position = SelectedMap.transform.position;
	}

	public string GetDescriptionText()
	{

		var text = SelectedMap.text;
		text += "\n\n\n";
		if (SelectedMap.Candidate != null)
			text += SelectedMap.Candidate.Requirements.GetBeingPower();
		text += "\n\n";
		foreach (var item in SelectedMap.Upgrades)
			text += item.GetText();
		return text;
	}
}

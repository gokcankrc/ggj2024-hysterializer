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
		SelectionText.text = SelectedMap.text;
		SelectionCircle.SetActive(true);
		SelectionCircle.transform.position = SelectedMap.transform.position;
	}
}

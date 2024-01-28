using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapButton : MonoBehaviour, IPointerClickHandler
{

	public bool IsUnlocked = false;
	public bool HasBeenFinished = false;
	public int Index = -1;
	public string text;
	public Being Candidate;
	public List<MapButton> Unlocks = new List<MapButton>();
	[SerializeReference, SubclassSelector] public List<Upgrade> Upgrades = new List<Upgrade>();

	[SerializeField] Image image;
	[SerializeField] Color Locked;
	[SerializeField] Color Unlocked;
	[SerializeField] Color Finished;

	private void Start()
	{
		RefreshVisuals();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		var mapMan = MapManager.I;
		mapMan.Select(this);
	}

	public void Finish()
	{
		if (HasBeenFinished) return;
		HasBeenFinished = true;
		foreach (var map in Unlocks)
		{
			map.IsUnlocked = true;
			map.RefreshVisuals();
		}
		RefreshVisuals();
	}

	public void TryLoad(int i)
	{
		var save = PlayerPrefs.GetInt($"MapSave{i}", 0);
		if (save != 0)
			Finish();
		RefreshVisuals();
	}

	public void TrySave(int i)
	{
		if (HasBeenFinished)
			PlayerPrefs.SetInt($"MapSave{i}", 1);
		else
			PlayerPrefs.SetInt($"MapSave{i}", 0);
	}

	public void Deselect() { }

	private void RefreshVisuals()
	{
		if (IsUnlocked)
		{
			if (HasBeenFinished)
				image.color = Finished;
			else
				image.color = Unlocked;
		}
		else
		{
			image.color = Locked;
		}
	}
}

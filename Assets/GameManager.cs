using RegularDuck._Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameObject GunParent;
	public GameObject MapParent;
	public Action ScreenTransitionDone;

	protected override void Awake()
	{
		base.Awake();
		SwitchToMap();
	}

	public void SwitchToMap()
	{
		if (RecruitButton.IsBusy) return;
		GunParent.SetActive(false);
		MapParent.SetActive(true);
		ScreenTransitionDone?.Invoke();
	}

	public void SwitchToGun()
	{
		MapParent.SetActive(false);
		GunParent.SetActive(true);
		ScreenTransitionDone?.Invoke();
	}
}

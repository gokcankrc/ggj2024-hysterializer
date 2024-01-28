using RegularDuck._Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameObject GunParent;
	public GameObject MapParent;

	public void SwitchToMap()
	{
		GunParent.SetActive(false);
		MapParent.SetActive(true);
	}

	public void SwitchToGun()
	{
		MapParent.SetActive(false);
		GunParent.SetActive(true);
	}
}
